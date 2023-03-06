using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;


namespace chapter4_B
{
    class meshes : System.Windows.Forms.Form
    {
        Device device;
        Mesh nesne;

        public meshes()
        {
            grafik_algila();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Render();
            Invalidate();
        }


        public void grafik_algila()
        {

            PresentParameters parametre = new PresentParameters();
            parametre.SwapEffect = SwapEffect.Discard;
            parametre.Windowed = true;
            parametre.EnableAutoDepthStencil = true;
            parametre.AutoDepthStencilFormat = DepthFormat.D16;

            device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, parametre);
            
            device.DeviceReset += new System.EventHandler(this.OnResetDevice);
            OnResetDevice(device, null);
            mesh_yukle();
        }
        Material[] meshmateryal;
        Texture[] mesh_doku;
        ExtendedMaterial[] materyaller = null;

        public void mesh_yukle()
        {
            if (mesh_doku == null && materyaller.Length > 0)
            {

                mesh_doku = new Texture[materyaller.Length];
                meshmateryal = new Material[materyaller.Length];

                for (int i = 0; i < materyaller.Length; i++)
                {
                    meshmateryal[i] = materyaller[i].Material3D;



                    try
                    {
                        if (materyaller[i].TextureFilename != null && materyaller[i].TextureFilename != String.Empty)
                            mesh_doku[i] = TextureLoader.FromFile(device, materyaller[i].TextureFilename);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }
                }

            }


        }

        private void Render()
        {
            device.Clear(ClearFlags.ZBuffer | ClearFlags.Target,
                                Color.Green, 1.0f, 0);

            device.BeginScene();

    //noktasal isiklandirma
 device.Lights[0].Type = LightType.Point;
    device.Lights[0].Diffuse = Color.Yellow;
    device.Lights[0].Direction = new Vector3(0, 0, -1);
    device.Lights[0].Position = new Vector3(0, 0, 80);
    device.Lights[0].Range = 73;
    device.Lights[0].Enabled = true;
      


        

            kamera();
           for (int i = 0; i < meshmateryal.Length; i++)
            {

                device.Material = meshmateryal[i];
                device.SetTexture(0, mesh_doku[i]);
                nesne.DrawSubset(i);

            }

            device.EndScene();
            device.Present();

        }
        private void OnResetDevice(object sender, EventArgs e)
        {

            device = (Device)sender;
            //Baska nesneler tanimlanacaksa farkli device nesneleri olusturulacak

            device.RenderState.Lighting = true;//isik açilsin
            nesne = Mesh.FromFile("a2a.x", MeshFlags.Managed, device, out materyaller);//materyalde alacak
        }

        public void kamera()
        {

            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4,
                    800 / 600, 0.0f, 3500.0f);


            device.Transform.View = Matrix.LookAtLH(new Vector3(0f, 0, 120.0f), new Vector3(0, 0, 0),
                 new Vector3(0, 1, 0));

        }
        static void Main()
        {
            meshes frm = new meshes();
            frm.Text = "Point";
            frm.Show();
            Application.Run(frm);
        }

    }
}
