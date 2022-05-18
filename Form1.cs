using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hide_and_Seek
{
    public partial class Form1 : Form
    {
        int Moves;

        Location currentLocation;

        RoomWithDoor livingRoom;
        RoomWithHidingPlace diningRoom;
        RoomWithDoor kitchen;
        Room stairs;
        Room attic; // чердак
        RoomWithHidingPlace hallway;
        RoomWithHidingPlace bathroom;
        RoomWithHidingPlace masterBedroom;
        RoomWithHidingPlace secondBedroom;

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        OutsideWithHidingPlace garden;
        OutsideWithHidingPlace driveway;

        Opponent opponent;

        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            opponent = new Opponent(frontYard);
            ResetGame(false);
            GameOver(false);
        }

        private void MoveToANewLocation(Location newLocation)
        {
            Moves++;
            currentLocation = newLocation;
            RedrawForm();
        }

        private void RedrawForm()
        {
            exits.Items.Clear();
            for (int i = 0; i < currentLocation.Exits.Length; i++)
                exits.Items.Add(currentLocation.Exits[i].Name);
            exits.SelectedIndex = 0;
            description.Text = currentLocation.Description + "\r\n(Перемещение #" + Moves + ")";
            if (currentLocation is IHidingPlace)
            {
                IHidingPlace hidingPlace = currentLocation as IHidingPlace;
                check.Text = "Проверить " + hidingPlace.HidingPlaceName;
                check.Visible = true;
            }
            else
                check.Visible = false;
            if (currentLocation is IHasExteriorDoor)
                goThroughTheDoor.Visible = true;
            else
                goThroughTheDoor.Visible = false;
            //====================================
            if (currentLocation == garden)
            {
                button2.Visible = true;
                goHere.Visible = false;
                exits.Visible = false;
                description.Text = "Вы в саду. Здесь есть сарай. Можете осмотреться";

                MessageBox.Show("Вы в саду. Здесь столько всего! Можно осмотреться");

            }
            //====================================
            if (currentLocation == attic)
            {
                description.Text = "Чердак. Вы в ловушке! Осмотритесь";
                timer1.Stop();
                timer1.Interval = 15000; // XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX Timer XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                button1.Visible = true;
                timer1.Enabled = true;

                goHere.Visible = false;
                exits.Visible = false;

                MessageBox.Show("Внимание! Вы в ловушке. Вам необходимо выбраться за 15 секунд");
                timer1.Start();
            }
        }

        private void CreateObjects()
        {
            //==================================================
            attic = new Room("Чердак", "в куче вещей");
            //==================================================
            livingRoom = new RoomWithDoor("Гостиная", "старинный ковёр",
                      "внутри шкафа", "дубовая дверь с латунной ручкой");
            diningRoom = new RoomWithHidingPlace("Столовая", "хрустальная люстра",
                       "в высоком шкафу");
            kitchen = new RoomWithDoor("Кухня", "плита из нержавеющей стали",
                      "в шкафу", "сетчатая дверь");
            stairs = new Room("Лестница", "деревянные перила");
            hallway = new RoomWithHidingPlace("Коридор наверху", "картина собаки",
                      "в шкафу");
            bathroom = new RoomWithHidingPlace("Ванная", "раковина и туалет",
                      "в душевой");
            masterBedroom = new RoomWithHidingPlace("Главная спальня", "большая кровать",
                      "под кроватью");
            secondBedroom = new RoomWithHidingPlace("Вторая спальня", "маленькая кровать",
                      "на кровати");

            frontYard = new OutsideWithDoor("Лужайка", false, "дубовая дверь с латунной ручкой");
            backYard = new OutsideWithDoor("Задний двор", true, "сетчатая дверь");
            garden = new OutsideWithHidingPlace("Сад", false, "внутри сарая");
            driveway = new OutsideWithHidingPlace("Дорога", true, "в гараже");

            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            livingRoom.Exits = new Location[] { diningRoom, stairs };
            kitchen.Exits = new Location[] { diningRoom };
            stairs.Exits = new Location[] { livingRoom, hallway };
            hallway.Exits = new Location[] { stairs, bathroom, masterBedroom, secondBedroom };
            bathroom.Exits = new Location[] { hallway };
            masterBedroom.Exits = new Location[] { hallway };
            secondBedroom.Exits = new Location[] { hallway };
            frontYard.Exits = new Location[] { backYard, garden, driveway };
            backYard.Exits = new Location[] { frontYard, garden, driveway };
            garden.Exits = new Location[] { attic, backYard, frontYard};
            driveway.Exits = new Location[] { backYard, frontYard };
            //=======================================
            attic.Exits = new Location[] { kitchen };
            //=======================================

            livingRoom.DoorLocation = frontYard;
            frontYard.DoorLocation = livingRoom;

            kitchen.DoorLocation = backYard;
            backYard.DoorLocation = kitchen;
        }

        private void ResetGame(bool displayMessage)
        {
            if (displayMessage)
            {
                MessageBox.Show("Ты нашёл меня в " + Moves + "!");
                IHidingPlace foundLocation = currentLocation as IHidingPlace;
                description.Text = "Ты нашёл своего соперника при " + Moves
                      + " перемещении! Он прятался в " + foundLocation.HidingPlaceName + ".";
            }
            Moves = 0;
            hide.Visible = true;
            goHere.Visible = false;
            check.Visible = false;
            goThroughTheDoor.Visible = false;
            exits.Visible = false;
            
            timer1.Stop();
        }

        private void GameOver(bool displayMessage)
        {
            if (displayMessage)
            {
                MessageBox.Show("К сожалению, ты не смог выбраться. Игра окончена...");
            }
            Moves = 0;
            hide.Visible = true;
            goHere.Visible = false;
            check.Visible = false;
            goThroughTheDoor.Visible = false;
            exits.Visible = false;

            timer1.Stop();
            description.Text = "Я начинаю считать!";
        }

        private void goHere_Click(object sender, EventArgs e)
        {
            MoveToANewLocation(currentLocation.Exits[exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor hasDoor = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(hasDoor.DoorLocation);
        }

        private void check_Click(object sender, EventArgs e)
        {
            Moves++;
            if (opponent.Check(currentLocation))
                ResetGame(true);
            else
                RedrawForm();
        }

        private void hide_Click(object sender, EventArgs e)
        {
            hide.Visible = false;

            for (int i = 1; i <= 10; i++)
            {
                opponent.Move();
                description.Text = i + "... ";
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }

            description.Text = "Готов ты или нет, но я иду!";
            Application.DoEvents();
            System.Threading.Thread.Sleep(500);

            goHere.Visible = true;
            exits.Visible = true;
            MoveToANewLocation(livingRoom);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myList = new List<string>(new string[] { "кольцо на полу", "дверь за кучей вещей", "окно", "лестница", "стул" });

            string things = myList[new Random().Next(myList.Count)];
            MessageBox.Show("Вы обнаружили " + things + "!");

            switch (things)
            {
                case "кольцо на полу":
                    MessageBox.Show("О, чудо! Это оказался выход.Спускайтесь в следующую локацию");
                    timer1.Stop();
                    goHere.Visible = true;
                    exits.Visible = true;
                    button1.Visible = false;
                    break;
                case "дверь за кучей вещей":
                    MessageBox.Show("К сожалению, это оказался шкаф... Продолжайте поиски");
                    break;
                case "окно":
                    MessageBox.Show("Хмм... Можно попробовать, но окно слишком высоко. Так что продолжайте поиски");
                    break;
                case "лестница":
                    MessageBox.Show("Можно попробовать выйти через окно, но оно слишком высоко. Ищите дальше");
                    break;
                case "стул":
                    MessageBox.Show("Можно посидеть и подумать. Но у вас мало времени. Продолжайте поиски");
                    break;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GameOver(true);
            button1.Visible = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myList2 = new List<string>(new string[] { "Дерево", "Забор", "Лестница" });

            string things2 = myList2[new Random().Next(myList2.Count)];

            switch (things2)
            {
                case "Лестница":
                    MessageBox.Show("Вы видите лестницу. Она ведёт на чердак. Он определённо прячется там!");
                    goHere.Visible = true;
                    exits.Visible = true;
                    button2.Visible = false;
                    break;
                case "Забор":
                    MessageBox.Show("Это просто забор. Его здесь нет. Ищи дальше");
                    break;
                case "Дерево":
                    MessageBox.Show("Я вижу дерево. Тут прохладно, но никого нет. Ищу дальше");
                    break;

            }
        }
    }
}