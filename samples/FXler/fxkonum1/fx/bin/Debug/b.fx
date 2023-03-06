struct kos_pixel
{
    float4 konum     : POSITION;


};

float4x4 ilkfx;

 kos_pixel boya( float4 knm : POSITION)
{
  kos_pixel kosegen = (kos_pixel)0;
  kosegen.konum =mul(knm, ilkfx);
    
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