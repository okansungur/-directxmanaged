using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;


namespace baslangic3
{
    public partial class Form1 : Form
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            try
            {


                device.Clear(ClearFlags.Target, System.Drawing.Color.CornflowerBlue, 1.0f, 0);


                Kamera();
                device.BeginScene();//Direct3D  birseyler cizicegimizi soledik



                //CustomVertex.TransformedColored[] verts = new CustomVertex.TransformedColored[3];
                //degistirdik!!!!!
                CustomVertex.PositionColored[] verts = new CustomVertex.PositionColored[3];
                verts[0].Position = new Vector3(0.0f, 1.0f, 1.0f);
                verts[0].Color = System.Drawing.Color.Aqua.ToArgb();
                verts[1].Position = new Vector3(-1.0f, -1.0f, 1.0f);
                verts[1].Color = System.Drawing.Color.Black.ToArgb();
                verts[2].Position = new Vector3(1.0f, -1.0f, 1.0f);
                verts[2].Color = System.Drawing.Color.Red.ToArgb();
        
                //device.VertexFormat = CustomVertex.TransformedColored.Format;
                device.VertexFormat = CustomVertex.PositionColored.Format;

                //Burada  Vector3 sinifi kullanildi artik uzay ortamina nesneler g�t�r�l�cek
                //device.VertexFormat kullanilarak direct3d ye cizilen verinin turunu 
                //degistirdigimizi soluyoruz

                //PrimitiveType ilkel tip olarak ��genler d�s�n�lmekte
                device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 2, verts);
                device.EndScene();
                device.Present();
                this.Invalidate();

            }
            catch (Exception ex)
            {

                MessageBox.Show( ex.ToString());

            }

        }


        float aci;//nesnenin d�nmesi i�in tanimladik
        private void Kamera()
        {
            //boyle bir ortamda Direct3D renkleri algilamasi isik yardimiyla olmaktadir
            //aksi takdirde ekranda objemiz siyah g�r�nt�lenecektir
            device.RenderState.Lighting = false;//isiklarin a�ilmasi gerekli

            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4,
                 this.Width / this.Height, 1.0f, 100.0f);
            //aspect ratio tvnin gorus alanini temsil etmekte orn tvnin genisligini 
            //yuksekligine boldugumuzde genelde (1.85) direct3D i�inde ayni durum s�zkonusu
            //znearplane parametresi piramitin tepesini zfarplane parametresi
            //ise piramitin tabanini g�stermektedir
            //(notlara bakiniz)
            device.Transform.View = Matrix.LookAtLH(new Vector3(0, 0, 5.0f), new Vector3(),
                 new Vector3(0, 1, 0));

            //Adim 1
            //device.Transform.World = Matrix.RotationZ((System.Environment.TickCount / 450.0f) / (float)Math.PI);

            //System.Environment.TickCount =15 ms s�reyi temsil etmektedir
            //GetTickCount() metodu Win32 API kullanmaktadir
            //Bu y�zden 15ms yerine 

            //Adim 2
            device.Transform.World = Matrix.RotationZ((aci / 450.0f) / (float)Math.PI);
            aci += 0.1f;
            //daha yavas bir sekilde d�n�s ger�eklesmekte Dikkat edilirse sadece 
            //Z eksenine g�re bir d�n�s saglanmakta

            //Adim 3
            //farkli eksenlerede bu d�n�s� yaymayi saglayabilirsek:

            device.Transform.World = Matrix.RotationAxis(new Vector3(aci / ((float)Math.PI * 2.0f),
    aci / ((float)Math.PI * 4.0f), aci / ((float)Math.PI * 6.0f)),
    aci / (float)Math.PI);
            //Matrix.RotationAxis() bize farkli eksenlerde d�n�s� m�mk�n kilmaktadir
            //D�n�sler esnesinda ��genin bazi b�l�mlerinin kayboldugu g�r�lmektedir
            //"back face culling" Direct3D ��geni render ederken bir y�zeyinin kamera 
            //tarafindan g�r�lmedigi i�in �izmemektedir buna ayrilma,kopma(back face culling) denilmektedir
            //bu �izilen b�l�mleri
            //device.RenderState.CullMode = Cull.Clockwise;
            //saat y�n� �izilmesin
            //   device.RenderState.CullMode = Cull.CounterClockwise;
            //saat y�n�n�n tersi �izilmesin
            device.RenderState.CullMode = Cull.None;
            //Artik "back face culling" sonlandirilmis olacak
        }


        private Device device = null;
        public void grafik_algila()
        {
            PresentParameters parametre = new PresentParameters();
            parametre.Windowed = true;
            parametre.SwapEffect = SwapEffect.Discard;
            device = new Device(0, DeviceType.Hardware, this,
            CreateFlags.SoftwareVertexProcessing, parametre);
        }
        public Form1()
        {
            grafik_algila();
            
            
            device.DeviceResizing += new CancelEventHandler(this.CancelResize);


            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);
        }
  

        private void CancelResize(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}