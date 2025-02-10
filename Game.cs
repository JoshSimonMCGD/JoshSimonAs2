// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    { 
        float starspeed = 25;

        float shootingstarx = 400;
        
        public void Setup()
        {
            Window.SetTitle("Night / Day");
            Window.SetSize(400, 400);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            
            // Declare Random Placement Variables.
            int starplacement1 = Random.Integer(400);
            int starplacement2 = Random.Integer(200);
            
            // Declare Mouse Position Variables.
            float mouseX = Input.GetMouseX();
            float mouseY = Input.GetMouseY();
            
            //Prevent Values above 400
            if (mouseX > 400)
            {
                mouseX = 400;
            }
            
            //Prevent Values bellow 0
            if (mouseX < 0)
            {
                mouseX = 0;
            }
            
            // Black to light blue cold color gradient. Sky Color. 
            float r = 0.0f;
            float g = mouseX / 600;
            float b = mouseX / 400;
            float c = mouseX / 400;
            
            // Black to white, through orange, warm color gradient. Sun Color. 
            float r2 = mouseX / 100;
            float g2 = mouseX / 200;
            float b2 = mouseX / 600;
            
            // Yellow to light blue color gradient. Moon Color.
            float r3 = 1.0f - ((1.0f / 400) * mouseX);
            float g3 = 0.8f - ((0.144444444444444444444444444444444444444f / 400) * mouseX);
            float b3 = mouseX / 400;
            
            //Cloud Color 1.
            float r4 = mouseX / 90;
            float g4 = mouseX / 300;
            float b4 = mouseX / 400;
            float c4 = 0.0f + ((1.0f / 400) * mouseX);
            
            // Backround
            ColorF bgColor = new ColorF(r, g, b);
            Window.ClearBackground(bgColor);
            
            // Moon Body
            Draw.LineColor= new ColorF(r3, g3, b3);
            Draw.FillColor = new ColorF(r3, g3, b3);;
            Draw.Circle(220 + mouseX / 2, 195 + mouseX / 2, 40);
            
            // Moon Hole
            Draw.LineColor = new ColorF(r, g, b);
            Draw.FillColor = new ColorF(r, g, b);;
            Draw.Circle(195 + mouseX / 2, 195 + mouseX / 2, 24);
            
            // Sun
            Draw.LineColor = new ColorF(r, g, b);
            Draw.FillColor = new ColorF(r2, g2, b2);
            Draw.Circle(mouseX / 2, 400 - mouseX / 2, 60);
            
            //Cloud 1
            Draw.LineColor = new ColorF(r4, g4, b4);
            Draw.FillColor = new ColorF(r4, g4, b4);
            Draw.Circle(100, 300, 40);
            
            //Cloud 2
            Draw.LineColor = new ColorF(r4, g4, b4);
            Draw.FillColor = new ColorF(r4, g4, b4);
            Draw.Circle(150, 270, 52);
            
            //Cloud 3
            Draw.LineColor = new ColorF(r4, g4, b4);
            Draw.FillColor = new ColorF(r4, g4, b4);
            Draw.Circle(205, 290, 49);
            
            //Cloud 4
            Draw.LineColor = new ColorF(r4, g4, b4);
            Draw.FillColor = new ColorF(r4, g4, b4);
            Draw.Circle(150, 315, 44);
            
            //Stars
            Draw.LineSize = 0;
            Draw.FillColor = new ColorF(r3, g3, b3);
            for (int i = 0; i < 5; i++)
            {
                int x = 60 + (i * 78) + (i * 5);
                int y = 20 + (i * 35) + (i * 5);
                Draw.Circle(x, y, 2);
            }
            for (int i = 0; i < 4; i++)
            {
                int x = 300 - (i * 100) + (i * 10);
                int y = 50 + (i * 25) + (i * 5);
                Draw.Circle(x, y, 2);
            }
            for (int i = 0; i < 4; i++)
            {
                int x = 160 - (i * 65) + (i * 10);
                int y = 10 + (i * 75) + (i * 5);
                Draw.Circle(x, y, 2);
            }
            for (int i = 0; i < 3; i++)
            {
                int x = 35 + (i * 125) + (i * 5);
                int y = 220 - (i * 25) + (i * 5);
                Draw.Circle(x, y, 2);
            }
            
            //Shooting Stars
            int[] Shootingstar = new int[400];
            
            //Allows Shooting Stars only at night
            if (mouseX <= 100)
            {
                if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
                {
                        shootingstarx -= Time.DeltaTime * starspeed;
                        Draw.LineColor = new ColorF(r3, g3, b3);
                        Draw.FillColor = new ColorF(r3, g3, b3);
                        Draw.Circle(shootingstarx, 200, 5);
                        
                }

            }
            
        }
    }
