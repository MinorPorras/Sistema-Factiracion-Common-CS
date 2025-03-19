namespace SistemaFactCS
{
    partial class M_SeleccionUsuario
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(M_SeleccionUsuario));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnCerrar = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Pic_TituloSU = new Guna.UI2.WinForms.Guna2PictureBox();
            this.flpUsuarios = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_TituloSU)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnCerrar.HoverState.ImageSize = new System.Drawing.Size(38, 38);
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnCerrar.ImageRotate = 0F;
            this.btnCerrar.ImageSize = new System.Drawing.Size(35, 35);
            resources.ApplyResources(this.btnCerrar, "btnCerrar");
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(38, 38);
            this.guna2ImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton1.Image")));
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(35, 35);
            resources.ApplyResources(this.guna2ImageButton1, "guna2ImageButton1");
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // Pic_TituloSU
            // 
            resources.ApplyResources(this.Pic_TituloSU, "Pic_TituloSU");
            this.Pic_TituloSU.ImageRotate = 0F;
            this.Pic_TituloSU.Name = "Pic_TituloSU";
            this.Pic_TituloSU.TabStop = false;
            // 
            // flpUsuarios
            // 
            resources.ApplyResources(this.flpUsuarios, "flpUsuarios");
            this.flpUsuarios.Name = "flpUsuarios";
            // 
            // M_SeleccionUsuario
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Controls.Add(this.flpUsuarios);
            this.Controls.Add(this.Pic_TituloSU);
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "M_SeleccionUsuario";
            this.Load += new System.EventHandler(this.M_SeleccionUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_TituloSU)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ImageButton btnCerrar;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private System.Windows.Forms.FlowLayoutPanel flpUsuarios;
        private Guna.UI2.WinForms.Guna2PictureBox Pic_TituloSU;
    }
}

