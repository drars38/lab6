using System;
using System.Drawing;

namespace lab6
{
    public class ColorPoint : IImpactPoint
    {
        public Color Color; // Цвет, который будет присвоен частице при пересечении
        public int Radius;

        public override void ImpactParticle(Particle particle)
        {
            // Проверяем, пересекается ли частица с точкой
            float distance = (float)Math.Sqrt(Math.Pow(X - particle.X, 2) + Math.Pow(Y - particle.Y, 2));
            float combinedRadius = Radius + particle.Radius; // Учитываем радиус точки и частицы

            if (distance <= combinedRadius)
            {
                // Если пересечение есть, меняем цвет частицы
                if (particle is ParticleColorful colorfulParticle)
                {
                    Console.WriteLine($"Particle at ({particle.X}, {particle.Y}) intersects with ColorPoint at ({X}, {Y})");
                    colorfulParticle.FromColor = Color;
                    colorfulParticle.ToColor = Color.FromArgb(0, Color);
                }
            }
        }

        public override void Render(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color))
            {
                g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }
}
