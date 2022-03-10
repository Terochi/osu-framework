﻿#include "sh_Utils.h"
#include "sh_TextureWrapping.h"
#include "sh_CircularProgressUtils.h"

varying lowp vec4 v_Colour;
varying mediump vec2 v_TexCoord;
varying mediump vec4 v_TexRect;

uniform lowp sampler2D m_Sampler;
uniform mediump float progress;
uniform mediump float innerRadius;

void main(void)
{
    if (progress == 0.0 || innerRadius == 0.0)
    {
        gl_FragColor = vec4(0.0);
        return;
    }

    vec2 resolution = v_TexRect.zw - v_TexRect.xy;
    vec2 pixelPos = v_TexCoord / resolution;
    
    gl_FragColor = insideProgress(pixelPos, progress, innerRadius) ? toSRGB(v_Colour * wrappedSampler(wrap(v_TexCoord, v_TexRect), v_TexRect, m_Sampler, -0.9)) : vec4(0.0);
}
