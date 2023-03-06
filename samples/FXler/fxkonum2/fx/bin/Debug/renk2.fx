struct kos_pixel
{
    float4 konum     : POSITION;
    float4 renk        : COLOR0;
};
float4x4 ilkfx;

 kos_pixel boya( float4 knm : POSITION)
{
  kos_pixel kosegen = (kos_pixel)0;
  kosegen.konum =mul(knm, ilkfx);
  
  //ekran koordinatlarina donusturme islemi
  //view*projection matris



       kosegen.renk.rg=0.8f;//renk için bu sekilde kisaltmalar kullanabilmekteyiz
    return kosegen;    
}
technique teknik
{
    pass Pass0
    {        
        VertexShader = compile vs_1_1 boya();
        PixelShader = NULL;
    }
}