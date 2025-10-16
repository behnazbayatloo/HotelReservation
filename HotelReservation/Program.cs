// See https://aka.ms/new-console-template for more information
using Figgle.Fonts;
using HotelReservation.Dtos;
using HotelReservation.Entities;
using HotelReservation.Enums;
using HotelReservation.Infrastructure.AppDb;
using HotelReservation.InMemorydb;
using HotelReservation.Interfaces.ServiceContracts;
using HotelReservation.Services;
using Spectre.Console;
using System;
using static Azure.Core.HttpHeader;


ILoginAthenticateService _login = new LoginAthenticateService();
IHotelRoomService _hotelroom = new HotelRoomService();
IRoomDetailService _room = new RoomDetailService();
IUserService _user = new UserService();
IReservationService _reserv=new ReservationService();
while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine(FiggleFonts.Standard.Render("Hotel Reservation"));
    Console.ResetColor();
    var select = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
                   .Title("[white]Select an option[/]")
                   .HighlightStyle("yellow")
                   .AddChoices(new[] { "Login", "Exit" })
           );
    try
    {
        switch (select)
        {
            case "Login":
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(FiggleFonts.Standard.Render("Login"));
                    Console.ResetColor();
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    var result = _login.Login(username, password);
                    if (result)
                    {

                        if (InMemoryDb.CurrentUser.Role == "Admin")
                        {
                            AdminMenue();
                        }
                        else if (InMemoryDb.CurrentUser.Role == "Receptionist")
                        {
                            ReciptionMenue();
                        }
                        else
                        {
                            NormalUserMenue();

                        }

                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Login Faild \nPassword Or Username wasnot correct.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }

                }
                break;
            case "Exit":
                {
                    Environment.Exit(0);
                }
                break;
        }

    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ResetColor();
        Console.ReadKey();

    }

}

void AdminMenue()
{
    while (InMemoryDb.IsAthenticate())
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(FiggleFonts.Standard.Render("Admin Menue"));
        Console.ResetColor();
        var select = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .Title("[white]Select an option[/]")
                       .HighlightStyle("yellow")
                       .AddChoices(new[] { "Add Room", "Logout" })
                        );

        try
        {
            switch (select)
            {
                case "Add Room":
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(FiggleFonts.Standard.Render("Add Room"));
                        Console.ResetColor();
                        Console.Write("if you want choose detail from exist details enter 1 or create new one enter 2: ");
                        string result = Console.ReadLine();
                        int detailid = 0;
                        if (result == "1")
                        {
                            var list = _room.ShowRoomDetail();

                            var table = new Table()
                            .Title("👩‍🏫 RoomDetails")
    .AddColumn("RoomId")
    .AddColumn("Description")
    .AddColumn("HasAirConditioner")
    .AddColumn("HasWifi")
    .Border(TableBorder.Rounded)
    .Centered();
                            foreach (var name in list)
                            {
                                table.AddRow(name.RoomId.ToString(), name.Description.ToString(), name.HasAirConditioner.ToString(), name.HasWifi.ToString());
                                table.UseSafeBorder = true;
                                table.ShowRowSeparators = true;
                            }

                            AnsiConsole.Write(table);
                            Console.Write("enter detailid: ");
                            detailid = Int32.Parse(Console.ReadLine());

                        }
                        else if (result == "2")
                        {
                            Console.Write("Description: ");
                            string description = Console.ReadLine();
                            Console.Write("If it has AirCondition enter true and else enter false");
                            var output1 = bool.TryParse(Console.ReadLine(), out bool outresult1);
                            Console.Write("If it has Wifi enter true and else enter false");
                            var output2 = bool.TryParse(Console.ReadLine(), out bool outresult2);
                            detailid = _room.AddRoomDetail(description, output1, output2);
                            Console.WriteLine($"RoomDetailId={detailid}");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("enter correct one");
                            Console.ReadKey();
                        }


                        Console.Write("enter RoomNumber: ");
                        string roomnumber= Console.ReadLine();
                        Console.Write("enter Cpacity: ");
                        int capacity = Int32.Parse(Console.ReadLine());
                        Console.Write("enter Price per night: ");
                        string input = Console.ReadLine();
                        float price = 0;
                        if (float.TryParse(input, out float number))
                        {
                            price = number;
                        }
                        else
                        {
                            Console.WriteLine("Number isnot valid");
                        }
                        CreateRoomDto room = new CreateRoomDto()
                        {
                            Capacity = capacity,
                            PricePerNight = price,
                            RoomDetailId = detailid,
                            RoomNumber = roomnumber


                        };
                       if(_hotelroom.AddRoom(room))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("room added successfully");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Operation faild");
                            Console.ResetColor();
                            Console.ReadKey();


                        }
                    }
                    break;

                case "Logout":
                    InMemoryDb.CurrentUser = null;
                    break;

            }
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
            Console.ReadKey();

        }


    }
}

void ReciptionMenue()
{
    while (InMemoryDb.IsAthenticate())
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(FiggleFonts.Standard.Render("Reciption Menue"));
        Console.ResetColor();
        var select = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .Title("[white]Select an option[/]")
                       .HighlightStyle("yellow")
                       .AddChoices(new[] { "Reserve room", "Logout" })
                        );

        try
        {
            switch (select)
            {
                case "Reserve room":
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(FiggleFonts.Standard.Render("Reserve room"));
                        Console.ResetColor();
                        
                        var list = _user.ShowAll();

                        var table = new Table()
                        .Title("👩‍🏫 Customers")
.AddColumn("Id")
.AddColumn("Name")
.Border(TableBorder.Square)
.Centered();
                        foreach (var name in list)
                        {
                            table.AddRow(name.Id.ToString(), name.UserName.ToString());
                            table.UseSafeBorder = true;
                           
                        }

                        AnsiConsole.Write(table);
                       
                        Console.Write("enter customerID: ");
                        int  customerid = Int32.Parse(Console.ReadLine());
                        Console.Write("enter roomID: ");
                        int roomid=int.Parse(Console.ReadLine());
                        Console.Write("enter entry Date: ");
                        string userInput1 = Console.ReadLine();
                        DateTime entry= DateTime.Now;
                        if (DateTime.TryParse(userInput1, out DateTime date1))
                        {
                            entry = date1;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("it is not correct, enter correct one.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        Console.Write("enter Exit Date: ");
                        string userInput2 = Console.ReadLine();
                        DateTime exit = DateTime.Now;
                        if (DateTime.TryParse(userInput2, out DateTime date2))
                        {
                            exit = date2;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("it is not correct, enter correct one.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        bool reserve = _reserv.GenerateReserve(entry, exit, customerid, roomid, StatusEnum.Confirmed);
                        if (reserve)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("reserve successfully.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("reservation faild.");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                    }
                    break;

                case "Logout":
                    InMemoryDb.CurrentUser = null;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
            Console.ReadKey();

        }
    }
}

void NormalUserMenue()
{
    while (InMemoryDb.IsAthenticate())
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(FiggleFonts.Standard.Render("NormalUser Menue"));
        Console.ResetColor();
        var select = AnsiConsole.Prompt(
                   new SelectionPrompt<string>()
                       .Title("[white]Select an option[/]")
                       .HighlightStyle("yellow")
                       .AddChoices(new[] { "Show Resverations", "Logout" })
                        );

        try
        {
            switch (select)
            {
                case "Show Resverations":
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine(FiggleFonts.Standard.Render("Show Resverations"));
                        Console.ResetColor();
                        var list = _reserv.ShowAll(InMemoryDb.CurrentUser.Id);

                        var table = new Table()
                        .Title("👩‍🏫 Reservations")
.AddColumn("CheckInDate")
.AddColumn("CheckOutDate")
.AddColumn("HotelRoomId")
.AddColumn("Status")
.AddColumn("CreatedAt")
.Border(TableBorder.Square)
.Centered();
                        foreach (var name in list)
                        {
                            table.AddRow(name.CheckInDate.ToString(), name.CheckOutDate.ToString(),name.HotelRoomId.ToString(),name.Status.ToString(),name.CreatedAt.ToString());
                            table.UseSafeBorder = true;
                            table.ShowRowSeparators = true;
                        }

                        AnsiConsole.Write(table);
                        Console.ReadKey();

                    }
                    break;


                case "Logout":
                    InMemoryDb.CurrentUser = null;
                    break;
            }
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.Message);
            Console.ResetColor();
            Console.ReadKey();

        }
    }
}

