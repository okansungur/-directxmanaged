using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;
namespace snd
{
    class sesefekt3 : System.Windows.Forms.Form
    {
        private Button button1;

        public sesefekt3() {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sesefekt3
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.button1);
            this.Name = "sesefekt3";
            this.ResumeLayout(false);
       }
       public static void Main()
        {
            sesefekt3 g = new sesefekt3();
           
            g.Show();
            

            Application.Run(g);
        }



        Device device;
        SecondaryBuffer sound;
        public void InitializeSound()
        {
            device = new Device();
            device.SetCooperativeLevel(this, CooperativeLevel.Normal);

            BufferDescription desc = new BufferDescription();
            desc.ControlEffects = true;//efektleri kullanabilmek için bu deðer true atanmalý
            desc.GlobalFocus = true;
            //uygulama focus kaybetse bile ses dosyasý çalmalý

            sound = new SecondaryBuffer(@"b.wav", desc, device);

            EffectDescription[] effects = new EffectDescription[9];
           effects[0].GuidEffectClass = DSoundHelper.StandardChorusGuid;
            effects[1].GuidEffectClass = DSoundHelper.StandardEchoGuid;
            effects[2].GuidEffectClass = DSoundHelper.StandardFlangerGuid;
            effects[3].GuidEffectClass = DSoundHelper.StandardDistortionGuid;
            effects[4].GuidEffectClass = DSoundHelper.StandardWavesReverbGuid;
            effects[5].GuidEffectClass = DSoundHelper.StandardInteractive3DLevel2ReverbGuid;
            effects[6].GuidEffectClass = DSoundHelper.StandardParamEqGuid;
            effects[7].GuidEffectClass = DSoundHelper.StandardCompressorGuid;
            effects[8].GuidEffectClass = DSoundHelper.StandardGargleGuid;
          
          
            sound.Play(0, BufferPlayFlags.Looping);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            InitializeSound();
        }
    }
}
