struct vrtx_pix
{
    float4 knm     : POSITION;    
    float2 dokukoord    : TEXCOORD0;
};

struct pix_fr
{
    float4 renk : COLOR0;
};

float4x4 gor;
Texture gelendoku;
sampler orn = sampler_state 
{ texture = <gelendoku> ; magfilter = LINEAR; minfilter = LINEAR;  AddressU = mirror; };


 vrtx_pix vert_shader( float4 g_poz : POSITION)
{
    vrtx_pix ksgn = (vrtx_pix)0;
    ksgn.knm = mul(g_poz, gor);
    ksgn.dokukoord = mul(g_poz, gor);
    return ksgn;    
}

pix_fr pix_shader(vrtx_pix gknm)
{
    pix_fr ksgn = (pix_fr)0;
    ksgn.renk = tex2D(orn, gknm.dokukoord);
    return ksgn;
}

technique dokuveisik
{
    pass Pass0
    {
         VertexShader = compile vs_2_0 vert_shader();
         PixelShader = compile ps_2_0 pix_shader();
    }

}
