using IngresoStockServicioTecnicoRetail.Models;
using Microsoft.EntityFrameworkCore;

namespace IngresoStockServicioTecnicoRetail;
public class Fun
{
    public static async Task<VTrsolicitud?> BuscarSolicitud(string nroDocumento)
    {
        using var context = new ESCORIALContext();
        var solicitudRetailId = new Guid("98809E0D-4C3D-48C5-B030-02D6AC887E71");
        var solicitudesRetail = context.VTrsolicituds
            .Where(s => s.TipotransaccionId == solicitudRetailId);
        if (!solicitudesRetail.Any())
            return null;
        var solicitudRetail = await solicitudesRetail
            .FirstOrDefaultAsync(s => s.Numerodocumento == nroDocumento);
        return solicitudRetail;
    }

    public static async Task<List<VItemsolicitud>?> BuscarItemSolicitud(VTrsolicitud solicitudRetail, string codProducto)
    {
        using var context = new ESCORIALContext();
        var producto = await BuscarProducto(codProducto);
        if (producto is null)
            return null;
        var itemSolicitud = await context.VItemsolicituds
            .Where(i => i.PlaceownerId == solicitudRetail.Id && i.Numerodocumento == solicitudRetail.Numerodocumento && i.ReferenciaId == producto.Id).ToListAsync();
        return itemSolicitud;
    }

    public static async Task<VUdItemsolreparacionretail?> BuscarUdItemSolicitud(VItemsolicitud itemSolicitud, string nroSerie)
    {
        using var context = new ESCORIALContext();
        var udItemSolicitud = await context.VUdItemsolreparacionretails
                        .FirstOrDefaultAsync(ud => ud.BoOwnerId == itemSolicitud.Id && ud.Serieproducto == nroSerie);
        return udItemSolicitud;
    }

    public static async Task<Solitudcambioretailpicking?> BuscarSolicitudIngresada(string nroSerie)
    {
        using var context = new ESCORIALContext();
        var etiquetaIngresada = await context.Solitudcambioretailpickings
            .FirstOrDefaultAsync(e => e.SerieProducto == nroSerie);
        return etiquetaIngresada;
    }


    public static async Task<bool> InsertarNuevoIngreso(VTrsolicitud cabecera, VItemsolicitud item, VUdItemsolreparacionretail ud)
    {
        var nuevoIngreso = new Solitudcambioretailpicking
        {
            CodigoProducto = item.Nombrereferencia,
            FechaIngreso = DateTime.Now,
            ItemsolicitudId = item.Id,
            SerieProducto = ud.Serieproducto,
            SolicitudId = cabecera.Id,
            ProcesadoCalipso = false,
            FechaProcesadoCalipso = null,
            Id = Guid.NewGuid()
        };
        using var context = new ESCORIALContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Solitudcambioretailpickings.Add(nuevoIngreso);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public static bool CoincideSerie(string serieRetail, string seriePlaca) =>
        serieRetail.Equals(seriePlaca);

    private static async Task<VProducto?> BuscarProducto(string codProducto)
    {
        using var context = new ESCORIALContext();
        var producto = await context.VProductos
            .FirstOrDefaultAsync(p => p.Codigo.Replace("-", "").Replace(".", "") == codProducto);
        return producto;
    }
}