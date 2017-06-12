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
            this.wizardPage = new AeroWizard.WizardPage();
            this.troubleshootImage = new System.Windows.Forms.PictureBox();
            this.description = new System.Windows.Forms.Label();
            this.wizardControl = new AeroWizard.WizardControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.wizardPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.troubleshootImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardPage
            // 
            this.wizardPage.Controls.Add(this.progressBar1);
            this.wizardPage.Controls.Add(this.troubleshootImage);
            this.wizardPage.Controls.Add(this.description);
            this.wizardPage.Name = "wizardPage";
            this.wizardPage.Size = new System.Drawing.Size(490, 321);
            this.wizardPage.TabIndex = 0;
            this.wizardPage.Text = "Page Title";
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
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(4, 4);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(32, 15);
            this.description.TabIndex = 0;
            this.description.Text = "label";
            // 
            // wizardControl
            // 
            this.wizardControl.BackColor = System.Drawing.Color.White;
            this.wizardControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl.FinishButtonText = "Next";
            this.wizardControl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl.Location = new System.Drawing.Point(0, 0);
            this.wizardControl.Name = "wizardControl";
            this.wizardControl.Pages.Add(this.wizardPage);
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
            this.wizardPage.ResumeLayout(false);
            this.wizardPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.troubleshootImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private AeroWizard.WizardPage wizardPage;
        private AeroWizard.WizardControl wizardControl;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.PictureBox troubleshootImage;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}