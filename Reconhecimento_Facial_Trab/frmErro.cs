using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reconhecimento_Facial_Trab
{
    public partial class frmErro : Form
    {
        public frmErro(Exception ex)
        {

            InitializeComponent();

            String[] dados = new String[5];

            dados[0] = ex.Message;
            dados[1] = String.Empty;
            dados[2] = ex.StackTrace;
            dados[3] = String.Empty;
            dados[4] = ex.Source;

            txtDetalhe.Lines = dados;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
