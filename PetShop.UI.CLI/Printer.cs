using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = PetShop.Core.Entity.Type;

namespace PetShop.ConsoleApp
{
    class Printer : IPrinter
    {
        IPetService _petServ;
        public Printer(IPetService petServ)
        {
            this._petServ = petServ;
        }

        public void StartUI()
        {
            Console.Clear();
            Console.WriteLine();
            int numb = 0;
            Console.WriteLine(" 1. Show list of all Pets\n 2. Search Pets by Type\n 3. Create a new Pet\n 4. Delete Pet\n 5. Update a Pet\n 6. Sort Pets\n 7. Get 5 cheapest available Pets\n 8. Quit");
            try
            {
                numb = int.Parse(Console.ReadLine());
            } catch
            {
                Console.WriteLine(" Please type a number between 1 and 8!");
            }
            switch (numb)
            {
                case 1:
                    Console.Clear();
                    GetAllPet();
                    break;
                case 2:
                    Console.Clear();
                    SearchPetByType();
                    break;
                case 3:
                    Console.Clear();
                    AddNewPet();
                    break;
                case 4:
                    Console.Clear();
                    DeletePet();
                    break;
                case 5:
                    Console.Clear();
                    UpdatePet();
                    break;
                case 6:
                    Console.Clear();
                    SortPets();
                    break;
                case 7:
                    Console.Clear();
                    CheapestFive();
                    break;
                case 8:
                    Environment.Exit(-1);
                    break;
                default:
                    Console.ReadLine();
                    break;
            }

            StartUI();
        }

        void GetAllPet()
        {
            Console.WriteLine(" List of Animals:\n");
            foreach (Pet pet in _petServ.GetPets())
            {
                Console.WriteLine($" {pet.ID}. Name: {pet.Name}, Type: {pet.Type.ToString().ToLower()}, BirthDate: {pet.BirthDate.ToShortDateString()}, Sold in {pet.SoldDate.ToShortDateString()}, Color: {pet.Color}, Previous Owner: {pet.PreviousOwner.FirstName} {pet.PreviousOwner.LastName}, Price: {pet.Price} DKK");                  
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();

            StartUI();
        }

        void SearchPetByType()
        {
            Type type = TypeSelection();
            Console.WriteLine($" The {type.ToString().ToLower()}s in the database:\n");
            foreach (Pet pet in _petServ.GetPetByType(type))
            {
                Console.WriteLine($" {pet.ID}. Name: {pet.Name}, BirthDate: {pet.BirthDate.ToShortDateString()}, Sold in {pet.SoldDate.ToShortDateString()}, Color: {pet.Color}, Previous Owner: {pet.PreviousOwner.FirstName} {pet.PreviousOwner.LastName}, Price: {pet.Price} DKK");
            }

            Console.ReadLine();

            StartUI();
        }

        void AddNewPet()
        {
            int price, year, month, day;
            Type type = TypeSelection();

            Console.Write($" Type the name of the {type}: ");
            string name = Console.ReadLine();

            Console.WriteLine($" What color does {name} has?");
            string color = Console.ReadLine();

            Console.WriteLine($" How much {name} costs?");
            int.TryParse(Console.ReadLine(), out price);

            Console.WriteLine($" When did {name} born?");
            Console.WriteLine(" Year: ");
            int.TryParse(Console.ReadLine(), out year);
            Console.WriteLine(" Month: ");
            int.TryParse(Console.ReadLine(), out month);
            Console.WriteLine(" Day: ");
            int.TryParse(Console.ReadLine(), out day);
            DateTime birth = new DateTime(year, month, day);

            DateTime sold = DateTime.UtcNow;

            Pet p = new Pet()
            {
                ID = GetNextId(),
                Name = name,
                Color = color,
                BirthDate = birth,
                SoldDate = sold,
                Price = price
            };

            _petServ.AddPet(p);

            Console.WriteLine($" You've added {name} to the database.\n\nPress Enter to continue...");
            Console.ReadLine();

            StartUI();
        }

        void DeletePet()
        {
            ListAllPets();
            Console.Write(" Type the number of the animal you want to delete: ");
            int index = int.Parse(Console.ReadLine());
            if (_petServ.RemovePet(index))
            {
                Console.WriteLine(" The pet has been deleted from the database!");
            }
            else
            {
                Console.WriteLine(" The pet hasn't been deleted!");
            }
            Console.ReadLine();

            StartUI();
        }

        void UpdatePet()
        {
            Pet selectedAnimal = null;
            ListAllPets();
            List<Pet> pets = _petServ.GetPets();
            Console.Write(" Type the number of the pet you want to update: ");
            int index = int.Parse(Console.ReadLine());
            if (index > pets.Count())
            {
                Console.Clear();
                Console.WriteLine($"Please enter a number between 1 and {pets.Count()}!\n");
                UpdatePet();
            }
            else
            {
                foreach (Pet pet in pets)
                {
                    if (pet.ID == index)
                    {
                        selectedAnimal = pet;
                    }
                }
                Console.WriteLine(" What do you want to update?\n 1. Name\n 2. Color\n 3. Price");
                for (int i = 0; i < 3; i++)
                {
                    int choice = 0;
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        StartUI();
                    }
                    if (choice == 1)
                    {
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        selectedAnimal.Name = name;
                        continue;
                    }
                    else if (choice == 2)
                    {
                        Console.Write("Color: ");
                        string color = Console.ReadLine();
                        selectedAnimal.Color = color;
                        continue;
                    }
                    else if (choice == 3)
                    {
                        Console.Write("Price: ");
                        int price = int.Parse(Console.ReadLine());
                        selectedAnimal.Price = price;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                _petServ.UpdatePet(selectedAnimal);

                Console.WriteLine(" You've updated the selected pet.\n\nPress Enter to continue...");
                Console.ReadLine();

                StartUI();
            }
            
        }

        void SortPets()
        {
            Console.WriteLine(" Sort Pets:\n 1. By Name\n 2. By BirthDate\n 3. By SoldDate\n 4. By Color\n 5. By Price");
            int numb = int.Parse(Console.ReadLine());
            List<Pet> pets = _petServ.SortListOfPets(numb);
            foreach (Pet pet in pets)
            {
                switch (numb)
                {
                    case 1:
                        Console.WriteLine($" Name: {pet.Name}, BirthDate: {pet.BirthDate.ToShortDateString()}, Sold in {pet.SoldDate.ToShortDateString()}, Color: {pet.Color}, Price: {pet.Price} DKK");
                        break;
                    case 2:
                        Console.WriteLine($" BirthDate: {pet.BirthDate.ToShortDateString()}, Name: {pet.Name}, Sold in {pet.SoldDate.ToShortDateString()}, Color: {pet.Color}, Price: {pet.Price} DKK");
                        break;
                    case 3:
                        Console.WriteLine($" Sold in {pet.SoldDate}, Name: {pet.Name}, BirthDate: {pet.BirthDate}, Color: {pet.Color}, Price: {pet.Price} DKK");
                        break;
                    case 4:
                        Console.WriteLine($" Color: {pet.Color}, Name: {pet.Name}, BirthDate: {pet.BirthDate.ToShortDateString()}, Sold in {pet.SoldDate.ToShortDateString()}, Price: {pet.Price} DKK");
                        break;
                    case 5:
                        Console.WriteLine($" Price: {pet.Price} DKK, Name: {pet.Name}, BirthDate: {pet.BirthDate.ToShortDateString()}, Sold in {pet.SoldDate.ToShortDateString()}, Color: {pet.Color}");
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();

            StartUI();
        }

        void CheapestFive()
        {
            foreach (Pet pet in _petServ.TopFiveCheapest())
            {
                Console.WriteLine($" {pet.ID}. Name: {pet.Name}, BirthDate: {pet.BirthDate.ToShortDateString()}, Sold in {pet.SoldDate.ToShortDateString()}, Color: {pet.Color}, Previous Owner: {pet.PreviousOwner.FirstName} {pet.PreviousOwner.LastName}, Price: {pet.Price} DKK");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();

            StartUI();
        }

        void ListAllPets()
        {
            foreach (Pet pet in _petServ.GetPets())
            {
                Console.WriteLine($" {pet.ID}. Name: {pet.Name}, Type: {pet.Type.ToString().ToLower()}");
            }
        }

        Type TypeSelection()
        {
            Console.WriteLine(" Type the number of the animal you'd like to choose:\n");
            Console.WriteLine(" 1. DOG\n 2. CAT\n 3. SNAKE\n 4. HAMSTER\n 5. PARROT");

            int intType = int.Parse(Console.ReadLine());
            switch (intType)
            {
                case 1:
                    return Type.DOG;
                case 2:
                    return Type.CAT;
                case 3:
                    return Type.SNAKE;
                case 4:
                    return Type.HAMSTER;
                case 5:
                    return Type.PARROT;
                default:
                    return Type.CREATURE;
            }
        }

        int GetNextId()
        {
            return _petServ.GetPets().Count() + 1;
        }
    }
}
