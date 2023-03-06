using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace t_dokular
{

    public class trans_doku : Form
    {
        Device device;
        CustomVertex.PositionTextured[] kosegenler;
        Texture doku;
        public trans_doku()
        {

            grafik_algila();
            Kamera();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
        }

        public void grafik_algila()
        {
            PresentParameters parametre = new PresentParameters();
            parametre.Windowed = true;
            parametre.SwapEffect = SwapEffect.Discard;

            parametre.EnableAutoDepthStencil = true;
            parametre.AutoDepthStencilFormat = DepthFormat.D16;

            device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, parametre);

            device.RenderState.Lighting = false;

            device.RenderState.DestinationBlend = Blend.InvSourceAlpha;

            device.RenderState.AlphaBlendEnable = true;
            device.RenderState.SourceBlend = Blend.SourceAlpha;

        }
        private void Kamera()
        {
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 2, this.Width / this.Height, 0.3f, 500f);
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, 30), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        }



        protected override void OnPaint(PaintEventArgs pea)
        {
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Red, 1.0f, 0);
            device.BeginScene();
            device.VertexFormat = CustomVertex.PositionTextured.Format;
            ucgenciz();
            device.DrawUserPrimitives(PrimitiveType.TriangleList, 2, kosegenler);
            dokuekle();
            device.SetTexture(0, doku);
            device.EndScene();
            device.Present();
            this.Invalidate();
        }
        void ucgenciz()
        {
            kosegenler = new CustomVertex.PositionTextured[6];
            kosegenler[0].Position = new Vector3(15f, 15f, 0f);
            kosegenler[0].Tu = 0;
            kosegenler[0].Tv = 0;
            kosegenler[1].Position = new Vector3(-15f, -15f, 0f);
            kosegenler[1].Tu = 1;
            kosegenler[1].Tv = 1;
            kosegenler[2].Position = new Vector3(15f, -15f, 0f);
            kosegenler[2].Tu = 0;
            kosegenler[2].Tv = 1;
            kosegenler[3].Position = new Vector3(-15f, -15f, 0f);
            kosegenler[3].Tu = 1;
            kosegenler[3].Tv = 1;
            kosegenler[4].Position = new Vector3(15.0f, 15.0f, 0f);
            kosegenler[4].Tu = 0;
            kosegenler[4].Tv = 0;
            kosegenler[5].Position = new Vector3(-15f, 15f, 0f);
            kosegenler[5].Tu = 1;
            kosegenler[5].Tv = 0;


        }

        void dokuekle()
        {
            Color rnk = Color.FromArgb(255, 255, 255, 255);
            doku = TextureLoader.FromFile(device,
              "0.png", 128, 128, D3DX.Default, 0,
               Format.Unknown, Pool.Managed,
               Filter.Box, Filter.Point, rnk.ToArgb());

            //Filter.Box
            //Filter.Linear;
            //Filter.Triangle;
            //Filter.Point
        }
        static void Main()
        {
            using (trans_doku orn = new trans_doku())
            {
                orn.Show();
                Application.Run(orn);
            }

        }
    }

}
