struct kos_pixel
{
    float4 konum     : POSITION;
   
};

float4x4 ilkfx;



 kos_pixel boya( float4 knm : POSITION)
{
  kos_pixel kosegen = (kos_pixel)0;
  kosegen.konum =mul(knm, ilkfx);
 // kosegen.renk.r = 1.0f;
  //kosegen.renk.g = 0.0f;
  //kosegen.renk.b = 1.0f;
   
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