using System.Xml;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections;

namespace TroubleshootingWizard
{
    partial class InitiumTroubleshoot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitiumTroubleshoot));
            this.wizardPage1 = new AeroWizard.WizardPage();
            this.troubleshootImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wizardControl = new AeroWizard.WizardControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.wizardPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.troubleshootImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardPage1
            // 
            this.wizardPage1.Controls.Add(this.progressBar1);
            this.wizardPage1.Controls.Add(this.troubleshootImage);
            this.wizardPage1.Controls.Add(this.label1);
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(490, 321);
            this.wizardPage1.TabIndex = 0;
            this.wizardPage1.Text = "Page Title";
            // 
            // troubleshootImage
            // 
            this.troubleshootImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.troubleshootImage.Location = new System.Drawing.Point(110, 41);
            this.troubleshootImage.Name = "troubleshootImage";
            this.troubleshootImage.Size = new System.Drawing.Size(250, 250);
            this.troubleshootImage.TabIndex = 1;
            this.troubleshootImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label";
            // 
            // wizardControl
            // 
            this.wizardControl.BackColor = System.Drawing.Color.White;
            this.wizardControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl.FinishButtonText = "Next";
            this.wizardControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl.Location = new System.Drawing.Point(0, 0);
            this.wizardControl.Name = "wizardControl";
            this.wizardControl.Pages.Add(this.wizardPage1);
            this.wizardControl.Size = new System.Drawing.Size(537, 475);
            this.wizardControl.TabIndex = 0;
            this.wizardControl.Title = "Initium Troubleshooting Wizard";
            this.wizardControl.TitleIcon = ((System.Drawing.Icon)(resources.GetObject("wizardControl.TitleIcon")));
            this.wizardControl.SelectedPageChanged += new System.EventHandler(this.wizardControl_SelectedPageChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(110, 295);
            this.progressBar1.Visible = false;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(250, 23);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // InitiumTroubleshoot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 475);
            this.Controls.Add(this.wizardControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InitiumTroubleshoot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.InitiumTroubleshoot_Load);
            this.wizardPage1.ResumeLayout(false);
            this.wizardPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.troubleshootImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private AeroWizard.WizardPage wizardPage1;
        private AeroWizard.WizardControl wizardControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox troubleshootImage;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}