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
            this.btnHide = new Guna.UI2.WinForms.Guna2ImageButton();
            this.flpUsuarios = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lblNomPestaña = new System.Windows.Forms.Label();
            this.btnMaximize = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnCerrar
            // 
            resources.ApplyResources(this.btnCerrar, "btnCerrar");
            this.btnCerrar.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnCerrar.HoverState.ImageSize = new System.Drawing.Size(38, 38);
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnCerrar.ImageRotate = 0F;
            this.btnCerrar.ImageSize = new System.Drawing.Size(35, 35);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnHide
            // 
            resources.ApplyResources(this.btnHide, "btnHide");
            this.btnHide.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnHide.HoverState.ImageSize = new System.Drawing.Size(38, 38);
            this.btnHide.Image = ((System.Drawing.Image)(resources.GetObject("btnHide.Image")));
            this.btnHide.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnHide.ImageRotate = 0F;
            this.btnHide.ImageSize = new System.Drawing.Size(35, 35);
            this.btnHide.Name = "btnHide";
            this.btnHide.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnHide.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // flpUsuarios
            // 
            resources.ApplyResources(this.flpUsuarios, "flpUsuarios");
            this.flpUsuarios.Name = "flpUsuarios";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btnMinimize);
            this.guna2Panel2.Controls.Add(this.lblNomPestaña);
            this.guna2Panel2.Controls.Add(this.btnHide);
            this.guna2Panel2.Controls.Add(this.btnMaximize);
            this.guna2Panel2.Controls.Add(this.btnCerrar);
            resources.ApplyResources(this.guna2Panel2, "guna2Panel2");
            this.guna2Panel2.Name = "guna2Panel2";
            // 
            // btnMinimize
            // 
            resources.ApplyResources(this.btnMinimize, "btnMinimize");
            this.btnMinimize.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnMinimize.HoverState.ImageSize = new System.Drawing.Size(38, 38);
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnMinimize.ImageRotate = 0F;
            this.btnMinimize.ImageSize = new System.Drawing.Size(35, 35);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblNomPestaña
            // 
            resources.ApplyResources(this.lblNomPestaña, "lblNomPestaña");
            this.lblNomPestaña.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNomPestaña.Name = "lblNomPestaña";
            // 
            // btnMaximize
            // 
            resources.ApplyResources(this.btnMaximize, "btnMaximize");
            this.btnMaximize.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnMaximize.HoverState.ImageSize = new System.Drawing.Size(38, 38);
            this.btnMaximize.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximize.Image")));
            this.btnMaximize.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnMaximize.ImageRotate = 0F;
            this.btnMaximize.ImageSize = new System.Drawing.Size(35, 35);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // M_SeleccionUsuario
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.flpUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "M_SeleccionUsuario";
            this.Load += new System.EventHandler(this.M_SeleccionUsuario_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2ImageButton btnCerrar;
        private Guna.UI2.WinForms.Guna2ImageButton btnHide;
        private System.Windows.Forms.FlowLayoutPanel flpUsuarios;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ImageButton btnMinimize;
        private System.Windows.Forms.Label lblNomPestaña;
        private Guna.UI2.WinForms.Guna2ImageButton btnMaximize;
    }
}

