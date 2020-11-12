namespace Reconhecimento_Facial_Trab
{
    partial class FmrPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pcbFoto = new System.Windows.Forms.PictureBox();
            this.txtCadastro = new System.Windows.Forms.TextBox();
            this.tmrFoto = new System.Windows.Forms.Timer(this.components);
            this.pcbRecortada = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRecortada)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(685, 45);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(232, 43);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Cadastrar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // pcbFoto
            // 
            this.pcbFoto.Location = new System.Drawing.Point(16, 15);
            this.pcbFoto.Margin = new System.Windows.Forms.Padding(4);
            this.pcbFoto.Name = "pcbFoto";
            this.pcbFoto.Size = new System.Drawing.Size(657, 458);
            this.pcbFoto.TabIndex = 1;
            this.pcbFoto.TabStop = false;
            // 
            // txtCadastro
            // 
            this.txtCadastro.Location = new System.Drawing.Point(685, 15);
            this.txtCadastro.Margin = new System.Windows.Forms.Padding(4);
            this.txtCadastro.MaxLength = 50;
            this.txtCadastro.Name = "txtCadastro";
            this.txtCadastro.Size = new System.Drawing.Size(232, 22);
            this.txtCadastro.TabIndex = 2;
            // 
            // tmrFoto
            // 
            this.tmrFoto.Enabled = true;
            this.tmrFoto.Tick += new System.EventHandler(this.tmrFoto_Tick);
            // 
            // pcbRecortada
            // 
            this.pcbRecortada.Location = new System.Drawing.Point(685, 95);
            this.pcbRecortada.Name = "pcbRecortada";
            this.pcbRecortada.Size = new System.Drawing.Size(233, 206);
            this.pcbRecortada.TabIndex = 4;
            this.pcbRecortada.TabStop = false;
            // 
            // FmrPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 487);
            this.Controls.Add(this.pcbRecortada);
            this.Controls.Add(this.txtCadastro);
            this.Controls.Add(this.pcbFoto);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FmrPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reconhecimento Facial";
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRecortada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.PictureBox pcbFoto;
        private System.Windows.Forms.TextBox txtCadastro;
        private System.Windows.Forms.Timer tmrFoto;
        private System.Windows.Forms.PictureBox pcbRecortada;
    }
}

