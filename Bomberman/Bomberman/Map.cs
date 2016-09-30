using Bomberman.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO; //Read map file
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    public class Map
    {
        private MapObject[,] entityList; //initial entity list
        private List<MapObject> everyEntityList; //contains every entity (Dynamic ones incl.)
        Random random = new Random(); //for random features
        private int height;
        private int elementSize;
        private int width;
        private string path;

        public List<MapObject> EveryEntityList
        {
            get
            {
                return everyEntityList;
            }

            set
            {
                everyEntityList = value;
            }
        }

        public MapObject[,] EntityList
        {
            get
            {
                return entityList;
            }

            set
            {
                entityList = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public int ElementSize
        {
            get
            {
                return elementSize;
            }

            set
            {
                elementSize = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        #region Map Construction

        /// <summary>
        /// Read map file and create an two-dimensional array of elements.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool CreateMapFromFile(string filename)
        {
            //try to open the map file
            StreamReader reader;
            try
            {
                filename = System.IO.Path.Combine("Maps\\" + filename);
                this.Path = filename;
                reader = new StreamReader(filename);
            }
            catch (Exception)
            {   //could not read the file
                return false;
            }

            //read the map size
            string[] size;
            size = reader.ReadLine().Split(' ');
            if (!int.TryParse(size[0], out width))
                return false;
            if (!int.TryParse(size[1], out height))
                return false;

            //create entity colleciton acording readed map size
            EntityList = new MapObject[Width, Height];

            //read map entities and add them to the map component array
            for (int i = 0; i < Height; i++)
            {
                string line = reader.ReadLine();
                for (int j = 0; j < Width; j++)
                    CreateComponent(line[j], j, i);
            }

            //map has been loaded
            reader.Close();
            return true;
        }

        private void CreateComponent(char c, int x, int y)
        {   
            // digit means - it is a place for player
            if (char.IsDigit(c))
            {
                int whichPlayer = c - '0';
                this.EntityList[x, y] = new Spawner(x, y, whichPlayer);
            }
            else
            {
                MapObject newMapObject = null;
                switch (c)
                {
                    // empty spaces required to start the game
                    case ',': break;
                    // create stone
                    case 's': newMapObject = new Stone(x, y); break;
                    // '.' means some chests may be created
                    case '.':
                        if (random.Next(0, 10) < 8) //80% chance to create a chest
                        {
                            newMapObject = new Chest(x, y);
                            if (random.Next(0, 10) < 5) // 50% chance to create some bonus inside
                            {
                                int bonusRandom = random.Next(0, 5);
                                switch (bonusRandom)
                                {
                                    case 0:
                                        newMapObject = new Chest(x, y, Chest.bonusType.changePlayers);
                                        break;
                                    case 1:
                                        newMapObject = new Chest(x, y, Chest.bonusType.explosionPowerIncrease);
                                        break;
                                    case 2:
                                        newMapObject = new Chest(x, y, Chest.bonusType.oneUp);
                                        break;
                                    case 3:
                                        newMapObject = new Chest(x, y, Chest.bonusType.speedIncrease);
                                        break;
                                    case 4:
                                        newMapObject = new Chest(x, y, Chest.bonusType.maxBombIncrease);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        break;
                }
                if (newMapObject != null)   //just create an instace of this component, but do not load yet
                    this.EntityList[x, y] = newMapObject;
            }
        }

        //----------------------------------------------------
        //OBSOLETE
        /*public void DrawMap(MapObject[,] entities, System.Windows.Forms.Panel panel, Graphics graphics)
        {
            elementSize = (panel.Width / (width));
            //int elementSize = panel.Height / height;
            //iterate through MapObject
            Debug.WriteLine("elementSize = " + elementSize);
            Debug.WriteLine("entities.GetLength(0) = " + entities.GetLength(0));
            Debug.WriteLine("entities.GetLength(1) = " + entities.GetLength(1));
            for (int i = 0; i < entities.GetLength(0); i++)
            {
                for (int j = 0; j < entities.GetLength(1); j++)
                {
                    if (entities[i, j] is Stone)
                    {
                        // Create image.
                        Image newImage = Image.FromFile("Images/stone.png");
                        int imageSize = Int32.Parse((elementSize * 1.2).ToString());
                        Bitmap bitmapImage = ImageHandler.ResizeImage(newImage, imageSize, imageSize);
                        // Create Point for upper-left corner of image. ul stands fo upper-left (corner)
                        Point ulCorner = new Point(panel.Location.X + i * elementSize, panel.Location.Y + j * elementSize);
                        // Draw image to screen.
                        graphics.DrawImage(bitmapImage, ulCorner);
                    }
                    
                }

            }
        }*/
        //----------------------------------------------------

        /// <summary>
        /// Creates panels and sets their backgroundImages to corresponding to object types. Then shows the result on the given form.
        /// </summary>
        /// <param name="map">Map to draw</param>
        /// <param name="entities">Entity list to create on map</param>
        /// <param name="form">Form on which the method draws</param>
        /// <param name="panel">Panel which size matters</param>
        public void DrawMap(Map map, MapObject[,] entities,System.Windows.Forms.Form form, System.Windows.Forms.Panel panel)
        {
            //ElementSize = (panel.Width / (Width));
            ElementSize = (panel.Height / (Height));
            //iterate through MapObject
            Debug.WriteLine("elementSize = " + ElementSize);
            Debug.WriteLine("entities.GetLength(0) = " + entities.GetLength(0));
            Debug.WriteLine("entities.GetLength(1) = " + entities.GetLength(1));
            for (int i = 0; i < entities.GetLength(0); i++)
            {
                for (int j = 0; j < entities.GetLength(1); j++)
                {
                    MapObject mapObject = new MapObject(i, j);
                    if (entities[i, j] is Stone)
                    {
                        mapObject = entities[i, j] as Stone;
                        Methods.DrawEntity(mapObject, mapObject.Name, this, form, form.Controls.Find("panelGame", false)[0] as Panel, "Images/stone.png");
                        SetMapFormPanel(map, form, panel, entities[i, j]);
                    }
                    if (entities[i, j] is Chest)
                    {
                        mapObject = entities[i, j] as Chest;
                        Methods.DrawEntity(mapObject, mapObject.Name, this, form, form.Controls.Find("panelGame", false)[0] as Panel, "Images/chest.png", 0.9);
                        SetMapFormPanel(map, form, panel, entities[i, j]);
                    }
                }
            }
        }

        private static void SetMapFormPanel(Map map, Form form, Panel panel, MapObject mapObject)
        {
            mapObject.Map = map;
            mapObject.Panel = panel;
            mapObject.Form = form;
        }
    }

    #endregion
}
