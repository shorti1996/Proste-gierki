using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    /// <summary>
    /// Set of Methods which don't belong to one specified object type.
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Draw entity of specified size on a new panel and add it to everyEntityList.
        /// This variant is used to create map because mapObject has to be shown on the board,
        /// then on mapObject should be executed Map.SetMapFormPanel method.
        /// </summary>
        /// <param name="mapObject">Given entity</param>
        /// <param name="name">Desired name (combined with "x_y"</param>
        /// <param name="size">Desired size</param>
        /// <param name="map">Map in which the entity is placed</param>
        /// <param name="form">Form to draw on</param>
        /// <param name="panel">Panel to align to</param>
        /// <param name="Texture">Desired texture path</param>
        public static void DrawEntity(MapObject mapObject, String name, Map map, Form form, Panel panel, string texture, Double size = 1, Double time = 1)
        {
            //simulate dynamic names for panels
            name = name + mapObject.X + "_" + mapObject.Y;
            Size drawnElementSize = new Size((Int32)(map.ElementSize * size), (Int32)(map.ElementSize * size));
            Image backgroundImage = System.Drawing.Image.FromFile(texture);
            Panel newPanel = new Panel();
            newPanel.Size = drawnElementSize;
            int Xposition = panel.Location.X + (Int32)((mapObject.X * map.ElementSize) + (map.ElementSize - newPanel.Size.Width) / 2);
            int Yposition = panel.Location.Y + (Int32)((mapObject.Y * map.ElementSize) + (map.ElementSize - newPanel.Size.Width) / 2);
            newPanel.Location = new Point(Xposition, Yposition);
            mapObject.CorrespondingPanel = newPanel;
            if (map.EveryEntityList != null)
                map.EveryEntityList.Add(mapObject);
            newPanel.GetType().GetProperty("Name").SetValue(newPanel, name);
            newPanel.GetType().GetProperty("Name").SetValue(newPanel, name);
            form.Controls.Add(newPanel);
            if (Path.GetExtension(texture) == ".gif")
            {
                PictureBox newPictureBox = new PictureBox();
                newPictureBox.Bounds = newPanel.Bounds;
                newPanel.Controls.Add(newPictureBox);
                newPictureBox.Dock = DockStyle.Fill;
                newPictureBox.Image = backgroundImage;
                newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                newPictureBox.Show();
                newPictureBox.BringToFront();
            }
            else
            {
                newPanel.BackgroundImage = backgroundImage;
                newPanel.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        /// <summary>
        /// Draw entity of specified size on a new panel and add it to everyEntityList
        /// </summary>
        /// <param name="mapObject">Given entity</param>
        /// <param name="name">Desired name (combined with "x_y"</param>
        /// <param name="size">Desired size</param>
        /// <param name="map">Map in which the entity is placed</param>
        /// <param name="form">Form to draw on</param>
        /// <param name="panel">Panel to align to</param>
        /// <param name="Texture">Desired texture path</param>
        public static void DrawEntity(MapObject mapObject, String name, string texture, Double size = 1, Double time = 1)
        {
            //simulate dynamic names for panels
            name = name + mapObject.X + "_" + mapObject.Y;
            //calculate size and prepare image and panel
            Size drawnElementSize = new Size((Int32)(mapObject.Map.ElementSize * size), (Int32)(mapObject.Map.ElementSize * size));
            Image backgroundImage = System.Drawing.Image.FromFile(texture);
            Panel newPanel = new Panel();
            newPanel.Size = drawnElementSize;
            int Xposition = mapObject.Panel.Location.X + (Int32)((mapObject.X * mapObject.Map.ElementSize) + (mapObject.Map.ElementSize - newPanel.Size.Width) / 2);
            int Yposition = mapObject.Panel.Location.Y + (Int32)((mapObject.Y * mapObject.Map.ElementSize) + (mapObject.Map.ElementSize - newPanel.Size.Width) / 2);
            newPanel.Location = new Point(Xposition, Yposition);
            //IMPORTANT
            //set corresponding panel
            mapObject.CorrespondingPanel = newPanel;
            //add to comfortable list of elements because it is on the board and can interact with player
            if (mapObject.Map.EveryEntityList != null)
                mapObject.Map.EveryEntityList.Add(mapObject);
            //reflection, ewww
            newPanel.GetType().GetProperty("Name").SetValue(newPanel, name);
            newPanel.GetType().GetProperty("Name").SetValue(newPanel, name);
            mapObject.Form.Controls.Add(newPanel);
            //if texture is .gif, then create PictureBox to keep animation
            if (Path.GetExtension(texture) == ".gif")
            {
                PictureBox newPictureBox = new PictureBox();
                newPictureBox.Bounds = newPanel.Bounds;
                newPanel.Controls.Add(newPictureBox);
                newPictureBox.Dock = DockStyle.Fill;
                newPictureBox.Image = backgroundImage;
                newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                newPictureBox.Show();
                newPictureBox.BringToFront();
                /*Timer timer = new Timer() { Interval = 1 };
                timer.Tick += Timer_Tick;
                timer.Tick += (sender, e) => Timer_Tick(sender, e, newPictureBox);
                timer.Start();*/
            }
            else
            {
                newPanel.BackgroundImage = backgroundImage;
                newPanel.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        //Maybe in the future...
        /*private void DisposeGif(PictureBox pictureBox, Timer timer)
        {
            pictureBox.Image = null;
        }

        private static void Timer_Tick(object sender, EventArgs e, PictureBox pictureBox)
        {

            var frameDimension = pictureBox.Image.FrameDimensionsList[0];
            var x = new System.Drawing.Imaging.FrameDimension(frameDimension);
            int frameCount = pictureBox.Image.GetFrameCount(x);
            if (pictureBox.Image.SelectActiveFrame(x, 18) == 0)
            {
                var timer = sender as Timer;
                timer.Dispose();
                pictureBox.Dispose();
            }
        }*/

        public static bool DetectCollision(Panel panel1, Panel panel2)
        {
            if (panel1.Bounds.IntersectsWith(panel2.Bounds))
            {
                return true;
            }
            else
                return false;
        }

        public static bool DetectCollision(MapObject mapObject1, MapObject mapObject2)
        {
            if (mapObject1 != null && mapObject2 != null)
            {
                if (mapObject1.CorrespondingPanel != null && mapObject2.CorrespondingPanel != null)
                {
                    if (mapObject1.CorrespondingPanel.Bounds.IntersectsWith(mapObject2.CorrespondingPanel.Bounds))
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            return false;
        }

        public static void GameOver(Player Loser, Form form)
        {
            Form formGameOver = new FormGameOver("Gracz " + Loser.Name + " nie żyje", form);
            formGameOver.Show();
        }

        public void ClearGame(Map map, Form form)
        {
            foreach (MapObject mapObject in map.EveryEntityList)
            {
                if (mapObject.CorrespondingPanel != null)
                {
                    form.Controls.Remove(mapObject.CorrespondingPanel);
                }
            }
            map = null;
        }

        /// <summary>
        /// Gets list of ALL controls of given type
        /// </summary>
        /// <param name="control"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            try
            {
                var controls = control.Controls.Cast<Control>();
                //clever lambda expression
                return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                          .Concat(controls)
                                          .Where(c => c.GetType() == type);
            }
            catch (Exception) { Console.WriteLine("GetAll method has failed"); }
            return null;
        }

        public static void FlashPanel(Panel panel, int duration = 1000, string imagePath = "Images/explosion.png")
        {
            Image Oldimage = panel.BackgroundImage;
            Image newImage = Image.FromFile(imagePath);
            panel.BackgroundImage = newImage;
            Timer timer = new Timer() { Interval = duration };
            timer.Tick += (sender, e) => {
                panel.BackgroundImage = Oldimage;
                timer.Dispose();
            };
            timer.Start();
        }

    }
}
