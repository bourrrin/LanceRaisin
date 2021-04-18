
namespace facialRecon
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnRecon = new System.Windows.Forms.Button();
            this.btnRepositioning = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.Location = new System.Drawing.Point(12, 12);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(616, 426);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(665, 54);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(108, 40);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "Start videoCapture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.StartCapture_Click);
            // 
            // btnRecon
            // 
            this.btnRecon.Location = new System.Drawing.Point(665, 119);
            this.btnRecon.Name = "btnRecon";
            this.btnRecon.Size = new System.Drawing.Size(108, 41);
            this.btnRecon.TabIndex = 2;
            this.btnRecon.Text = "Detect face";
            this.btnRecon.UseVisualStyleBackColor = true;
            this.btnRecon.Click += new System.EventHandler(this.btnDetectFace_Click);
            // 
            // btnRepositioning
            // 
            this.btnRepositioning.Location = new System.Drawing.Point(665, 194);
            this.btnRepositioning.Name = "btnRepositioning";
            this.btnRepositioning.Size = new System.Drawing.Size(108, 40);
            this.btnRepositioning.TabIndex = 3;
            this.btnRepositioning.Text = "Initiate Repositioning";
            this.btnRepositioning.UseVisualStyleBackColor = true;
            this.btnRepositioning.Click += new System.EventHandler(this.btnRepositionning_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRepositioning);
            this.Controls.Add(this.btnRecon);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.picCapture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnRecon;
        private System.Windows.Forms.Button btnRepositioning;
    }
}

