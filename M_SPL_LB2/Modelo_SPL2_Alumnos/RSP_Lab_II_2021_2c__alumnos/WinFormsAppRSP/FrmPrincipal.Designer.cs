
namespace WinFormsAppRSP
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstTodos = new System.Windows.Forms.ListBox();
            this.lstDesaprobados = new System.Windows.Forms.ListBox();
            this.lstAprobados = new System.Windows.Forms.ListBox();
            this.lstPromocionados = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSerializar = new System.Windows.Forms.Button();
            this.btnDeserializar = new System.Windows.Forms.Button();
            this.btnHilos = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTodos
            // 
            this.lstTodos.FormattingEnabled = true;
            this.lstTodos.ItemHeight = 15;
            this.lstTodos.Location = new System.Drawing.Point(6, 22);
            this.lstTodos.Name = "lstTodos";
            this.lstTodos.Size = new System.Drawing.Size(833, 169);
            this.lstTodos.TabIndex = 0;
            // 
            // lstDesaprobados
            // 
            this.lstDesaprobados.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstDesaprobados.ForeColor = System.Drawing.Color.Red;
            this.lstDesaprobados.FormattingEnabled = true;
            this.lstDesaprobados.ItemHeight = 12;
            this.lstDesaprobados.Location = new System.Drawing.Point(6, 22);
            this.lstDesaprobados.Name = "lstDesaprobados";
            this.lstDesaprobados.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstDesaprobados.Size = new System.Drawing.Size(308, 136);
            this.lstDesaprobados.TabIndex = 1;
            // 
            // lstAprobados
            // 
            this.lstAprobados.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstAprobados.FormattingEnabled = true;
            this.lstAprobados.ItemHeight = 12;
            this.lstAprobados.Location = new System.Drawing.Point(6, 22);
            this.lstAprobados.Name = "lstAprobados";
            this.lstAprobados.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstAprobados.Size = new System.Drawing.Size(308, 136);
            this.lstAprobados.TabIndex = 2;
            // 
            // lstPromocionados
            // 
            this.lstPromocionados.BackColor = System.Drawing.SystemColors.Window;
            this.lstPromocionados.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstPromocionados.ForeColor = System.Drawing.Color.Blue;
            this.lstPromocionados.FormattingEnabled = true;
            this.lstPromocionados.ItemHeight = 12;
            this.lstPromocionados.Location = new System.Drawing.Point(6, 22);
            this.lstPromocionados.Name = "lstPromocionados";
            this.lstPromocionados.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstPromocionados.Size = new System.Drawing.Size(308, 136);
            this.lstPromocionados.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTodos);
            this.groupBox1.Location = new System.Drawing.Point(18, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(845, 212);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Todos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstDesaprobados);
            this.groupBox2.Location = new System.Drawing.Point(12, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 182);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Desaprobados";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstAprobados);
            this.groupBox3.Location = new System.Drawing.Point(353, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 182);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Aprobados";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstPromocionados);
            this.groupBox4.Location = new System.Drawing.Point(683, 239);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 182);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Promocionados";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAgregar.Location = new System.Drawing.Point(901, 43);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnModificar.Location = new System.Drawing.Point(901, 72);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Tomato;
            this.btnEliminar.Location = new System.Drawing.Point(901, 101);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnSerializar
            // 
            this.btnSerializar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSerializar.Location = new System.Drawing.Point(901, 141);
            this.btnSerializar.Name = "btnSerializar";
            this.btnSerializar.Size = new System.Drawing.Size(75, 23);
            this.btnSerializar.TabIndex = 8;
            this.btnSerializar.Text = "Serializar";
            this.btnSerializar.UseVisualStyleBackColor = false;
            // 
            // btnDeserializar
            // 
            this.btnDeserializar.BackColor = System.Drawing.Color.Fuchsia;
            this.btnDeserializar.Location = new System.Drawing.Point(901, 170);
            this.btnDeserializar.Name = "btnDeserializar";
            this.btnDeserializar.Size = new System.Drawing.Size(75, 23);
            this.btnDeserializar.TabIndex = 9;
            this.btnDeserializar.Text = "Deserializar";
            this.btnDeserializar.UseVisualStyleBackColor = false;
            // 
            // btnHilos
            // 
            this.btnHilos.BackColor = System.Drawing.Color.PeachPuff;
            this.btnHilos.Location = new System.Drawing.Point(901, 210);
            this.btnHilos.Name = "btnHilos";
            this.btnHilos.Size = new System.Drawing.Size(75, 23);
            this.btnHilos.TabIndex = 10;
            this.btnHilos.Text = "Hilos";
            this.btnHilos.UseVisualStyleBackColor = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 435);
            this.Controls.Add(this.btnHilos);
            this.Controls.Add(this.btnDeserializar);
            this.Controls.Add(this.btnSerializar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPrincipal";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTodos;
        private System.Windows.Forms.ListBox lstDesaprobados;
        private System.Windows.Forms.ListBox lstAprobados;
        private System.Windows.Forms.ListBox lstPromocionados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSerializar;
        private System.Windows.Forms.Button btnDeserializar;
        private System.Windows.Forms.Button btnHilos;
    }
}

