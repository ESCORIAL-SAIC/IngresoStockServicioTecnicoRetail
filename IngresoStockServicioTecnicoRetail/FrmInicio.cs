using IngresoStockServicioTecnicoRetail.Models;

namespace IngresoStockServicioTecnicoRetail;
public partial class FrmInicio : Form
{
    public List<(VTrsolicitud, VItemsolicitud, VUdItemsolreparacionretail)> pickedList = [];

    public FrmInicio()
    {
        InitializeComponent();
    }

    private async void BtnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (var row in pickedList)
            {
                var cabecera = row.Item1;
                var item = row.Item2;
                var ud = row.Item3;
                var insertadoCorrectamente = await Fun.InsertarNuevoIngreso(cabecera, item, ud);
                if (insertadoCorrectamente)
                    MessageBox.Show("El registro se insert� correctamente.", "Insert correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Hubo un error insertando", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            pickedList.Clear();
            DgvItemsIngresados.Rows.Clear();
            LimpiarCampos();
        }
    }

    private void LimpiarCampos()
    {
        TxtNumeroSerie.Text = string.Empty;
        TxtPlacaMarcado.Text = string.Empty;
        TxtNumeroSerie.Focus();
    }

    private void TxtNumeroSerie_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            TxtPlacaMarcado.Focus();
    }

    private async void TxtPlacaMarcado_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
            return;

        var codBarras = TxtNumeroSerie.Text;
        if (string.IsNullOrEmpty(codBarras))
        {
            MessageBox.Show("El numero de serie no puede estar vacio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LimpiarCampos();
            return;
        }
        var nroDocumento = codBarras[..8];
        var codProducto = codBarras.Substring(8, 9);
        var nroSerie = codBarras.Substring(17, 15);
        nroSerie = nroSerie.TrimStart('0');
        var serieMarcado = TxtPlacaMarcado.Text.TrimStart('0');

        if(pickedList.Any(item => item.Item3.Serieproducto == nroSerie))
        {
            MessageBox.Show("El n�mero de serie ya fue ingresado anteriormente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LimpiarCampos();
            return;
        }

        var cabecera = await Fun.BuscarSolicitud(nroDocumento);
        if (cabecera is null)
        {
            MessageBox.Show("No se encuentra el n�mero de documento indicado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LimpiarCampos();
            return;
        }
        var listItem = await Fun.BuscarItemSolicitud(cabecera, codProducto);
        if (listItem is null || listItem.Count == 0)
        {
            MessageBox.Show("No se encontr� el �tem asociado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LimpiarCampos();
            return;
        }
        VUdItemsolreparacionretail? ud = null;
        VItemsolicitud? item = null;
        foreach (var itemFor in listItem)
        {
            ud = await Fun.BuscarUdItemSolicitud(itemFor, nroSerie);
            if (ud is not null)
            {
                item = itemFor;
                break;
            }
        }
        if (ud is null || item is null)
        {
            MessageBox.Show("No se encontr� la UD o el �tem asociados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LimpiarCampos();
            return;
        }
        if (!Fun.CoincideSerie(ud.Serieproducto, serieMarcado))
        {
            var res = MessageBox.Show("No coinciden el n�mero de serie indicado en la etiqueta retail con el escaneado en la cocina.\nDesea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.No)
                return;
        }
        var solicitudIngresada = await Fun.BuscarSolicitudIngresada(nroSerie);
        if (solicitudIngresada is not null)
        {
            MessageBox.Show("El numero de serie ya fue previamente ingresado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LimpiarCampos();
            return;
        }
        pickedList.Add((cabecera, item, ud));
        DgvItemsIngresados.Rows.Add(cabecera.Numerodocumento, item.Nombrereferencia, ud.Serieproducto);
        LimpiarCampos();
    }
}