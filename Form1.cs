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

        Random rnd = new Random();
        Location currentLocation;

        RoomWithDoor livingRoom;
        RoomWithHidingPlace diningRoom;
        RoomWithDoor kitchen;
        Room stairs;
        //GardenGame attic;
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
            if (currentLocation == kitchen)
            {
                check.Visible = false;
                goThroughTheDoor.Visible = false;
                goHere.Visible = false;
                exits.Visible = false;
                button1.Visible = true;
                textBox1.Visible = true;
                description.Text = "Злой повар заставил вас съесть его блюда в определённом порядке." +
                    "У вас есть 10 попыток, чтобы выбраться отсюда. Иначе игра будет окончена";

                MessageBox.Show("Хе-хе-хе, я злой повар! Закормлю тебя до смерти, " +
                    "если ты за 10 попыток не составишь правильный порядок моих блюд");
                MessageBox.Show("Вам даны блюда под номерами 1, 2, 3. Вы должны составить их правильный порядок");

            }
            //====================================
        }

        private void CreateObjects()
        {

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
            garden.Exits = new Location[] { backYard, frontYard };
            driveway.Exits = new Location[] { backYard, frontYard };

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
            button1.Visible = false;
        }

        //========================================================================
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
            button1.Visible = false;

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


        static string[] mas = new string[10];
        static int k = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (k != 10)
            {
                textBox1.Text = Convert.ToString(rnd.Next(1, 3)) +
                    Convert.ToString(rnd.Next(1, 3)) +
                    Convert.ToString(rnd.Next(1, 3));
                mas[k] = textBox1.Text;
                k++;
            }
            else GameOver(true);
        }
    }
}