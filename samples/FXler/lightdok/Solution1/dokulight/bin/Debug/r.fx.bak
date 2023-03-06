struct vrtx_pix
{
    float4 knm     : POSITION;    
    float2 dokukoord    : TEXCOORD0;//doku koordinatlarý
    float3 Normal        : TEXCOORD1;//kosegen normalleri

};
struct pix_fr
{
    float4 renk : COLOR0;
};
 float4x4 gor;
 float4x4 donen;
 float4 isik_knm;
 float isik_guc;
 Texture gelendoku;
sampler orn = sampler_state { texture = <gelendoku> ; magfilter = LINEAR; minfilter = LINEAR; mipfilter=LINEAR; AddressU = mirror; AddressV = mirror;};

 vrtx_pix vert_shader( float4 g_poz : POSITION,  float3 g_norm : NORMAL)
{
    vrtx_pix ksgn = (vrtx_pix)0;
    ksgn.knm = mul(g_poz, gor);
    ksgn.dokukoord = g_poz;
    ksgn.Normal = mul(g_norm, donen);
    return ksgn;    
}
  
 float dot_product(float4 isikknm,  float3 g_normal)
 {
     float3 isikyonu = normalize(isikknm );
     return dot(isikyonu, g_normal);
 }


pix_fr pix_shader(vrtx_pix gknm)
{
    pix_fr ksgn = (pix_fr)0;
     float yayilanisik = dot_product(isik_knm, gknm.Normal);
     ksgn.renk = tex2D(orn, gknm.dokukoord)*yayilanisik*isik_guc;

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
