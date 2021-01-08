Shader "Custom/WireFlat" {

	Properties {
		_Color ("Diffuse Material Color", Color) = (1,1,1,1)
		_Ramp ("Ambient lighting, min darkness", Range(0,1)) = 0
	}

	SubShader {
		Pass {
			Tags { "LightMode" = "ForwardBase" } 
			
			
			GLSLPROGRAM
			
			uniform vec4 _Color;
			uniform float _Ramp;
			
			uniform mat4 _Object2World; // model matrix
			uniform mat4 _World2Object; // inverse model matrix
			uniform vec4 _WorldSpaceLightPos0; 
			// direction to or position of light source
			uniform vec4 _LightColor0; 
			
			
			#ifdef VERTEX
				out vec4 colour;
				void main() {
					gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
					
					vec3 normalDirection = normalize(vec3(vec4(gl_Normal, 0.0) * _World2Object));
					vec3 lightDirection = normalize(vec3(_WorldSpaceLightPos0));

					vec3 diffuseReflection = vec3(_LightColor0) * vec3(_Color)
						* max(_Ramp, dot(normalDirection, lightDirection));

					colour = vec4(diffuseReflection, 1.0);
				}
			#endif


			#ifdef FRAGMENT
				in vec4 colour;
				void main() {
					gl_FragColor = colour; 
				}
			#endif

			ENDGLSL
		}
	}
}