﻿namespace MainApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnRankingJogador = new System.Windows.Forms.Button();
            this.btnRankingMortes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(69, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(487, 46);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Analizador Quake 3 Arena";
            // 
            // btnRankingJogador
            // 
            this.btnRankingJogador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRankingJogador.Location = new System.Drawing.Point(38, 138);
            this.btnRankingJogador.Name = "btnRankingJogador";
            this.btnRankingJogador.Size = new System.Drawing.Size(267, 41);
            this.btnRankingJogador.TabIndex = 1;
            this.btnRankingJogador.Text = "Raking Geral por Jogador";
            this.btnRankingJogador.UseVisualStyleBackColor = true;
            this.btnRankingJogador.Click += new System.EventHandler(this.btnRankingJogador_Click);
            // 
            // btnRankingMortes
            // 
            this.btnRankingMortes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRankingMortes.Location = new System.Drawing.Point(330, 138);
            this.btnRankingMortes.Name = "btnRankingMortes";
            this.btnRankingMortes.Size = new System.Drawing.Size(267, 41);
            this.btnRankingMortes.TabIndex = 2;
            this.btnRankingMortes.Text = "Ranking de Mortes";
            this.btnRankingMortes.UseVisualStyleBackColor = true;
            this.btnRankingMortes.Click += new System.EventHandler(this.btnRankingMortes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 258);
            this.Controls.Add(this.btnRankingMortes);
            this.Controls.Add(this.btnRankingJogador);
            this.Controls.Add(this.lblTitulo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quake 3 Arena";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnRankingJogador;
        private System.Windows.Forms.Button btnRankingMortes;
    }
}

