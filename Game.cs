// Day / Night Cycle
using System;
using System.Numerics;
// This Program creates a Day / Night cycle based on mouse movement across the x axis. Originally, the program was also
// meant to allow the user to create a randomly generated shooting star during the night cycle. Shooting star update coming soon.

namespace MohawkGame2D;
    public class Game
    { 
        // Framecount Variable.
        int frameCount = 0;
        
        // Starting Cloud Position.
        float cloudpositionX = 0;
        
        // Setup.
        public void Setup()
        {
            Window.SetTitle("Night / Day");
            Window.SetSize(400, 400);
        }
        
        public void Update()
        {
            // Most variables. Variables not responding while outside of 'public void'. Will ask about the issue next class.
            
            // Declare Mouse Position Variables.
            float mouseX = Input.GetMouseX();
            
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
            
            // All Color Variables:
            
            // Black to light blue cold color gradient. Sky Color. 
            float r = 0.0f;
            float g = mouseX / 600;
            float b = mouseX / 400;
            
            // Black to white, through orange, warm color gradient. Sun Color. 
            float r2 = mouseX / 100;
            float g2 = mouseX / 200;
            float b2 = mouseX / 600;
            
            // Yellow to light blue color gradient. Moon Color.
            float r3 = 1.0f - ((1.0f / 400) * mouseX);
            float g3 = 0.8f - ((0.144444444444444444444444444444444444444f / 400) * mouseX);
            float b3 = mouseX / 400;
            
            // Deep Yellow to light blue color gradient. Star Color.
            float r5 = 1.0f - ((1.0f / 400) * mouseX);
            float g5 = 0.7f - ((0.044444444444444444444444444444444444444f / 400) * mouseX);
            float b5 = mouseX / 400;
            
            //Cloud Color.
            float r4 = mouseX / 90;
            float g4 = mouseX / 300;
            float b4 = mouseX / 400;
            float c4 = 0.0f + ((1.0f / 400) * mouseX);
            
            // Visual Assets:
            
            // Backround
            ColorF bgColor = new ColorF(r, g, b);
            Window.ClearBackground(bgColor);
            
            //Stars
            Draw.LineSize = 0;
            Draw.FillColor = new ColorF(r5, g5, b5);
            
            // Creates consistent and somewhat accurate star placement. While random variables could have been used 
            // like the example shown in class, random variables for star placement did not look cohesive with the rest
            // of the piece.
            
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
            
            // Draw Moon function combining the moon with its inner circle making it appear to be crescent.

            void DrawMoon(float moonX, float moonY)
            {
                Draw.LineColor= new ColorF(r3, g3, b3);
                Draw.FillColor = new ColorF(r3, g3, b3);;
                Draw.Circle(moonX + mouseX / 2, moonY + mouseX / 2, 40);
            
                // Moon Hole
                Draw.LineColor = new ColorF(r, g, b);
                Draw.FillColor = new ColorF(r, g, b);;
                Draw.Circle(moonX - 25 + mouseX / 2, moonY + mouseX / 2, 24);
            }
            DrawMoon(220, 195);
            
            // Sun
            Draw.LineColor = new ColorF(r, g, b);
            Draw.FillColor = new ColorF(r2, g2, b2);
            Draw.Circle(mouseX / 2, 400 - mouseX / 2, 60);
            
            // Addint 'DeltaTime' to the cloud placement to create movement.
            cloudpositionX += Time.DeltaTime * 70;
            
            //Clouds
            Draw.LineColor = new ColorF(r4, g4, b4);
            Draw.FillColor = new ColorF(r4, g4, b4);
            Draw.Circle(cloudpositionX - 150, 300, 40);
            Draw.Circle(cloudpositionX - 100, 270, 52);
            Draw.Circle(cloudpositionX - 50, 290, 49);
            Draw.Circle(cloudpositionX - 95, 315, 44);
            
            // Causes the cloud to return to it's starting position after exiting the window area. 
            if (cloudpositionX > Window.Width + 200)
            {
                cloudpositionX = 0;
            }
            
            //Shooting Stars
            int[] Shootingstar = new int[400];
            
            //Allows Shooting Stars only at night
            if (mouseX <= 100)
            {
                // Diactivated Code contributing to the 'Shooting Star' component of the program. Still a working progress.
                
                if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
                {
                        // shootingstarx -= Time.DeltaTime * starspeed;
                       // Draw.LineColor = new ColorF(r3, g3, b3);
                        // Draw.FillColor = new ColorF(r3, g3, b3);
                       //  Draw.Circle(shootingstarx, 200, 5);
                        
                }

            }
            
        }
    }
