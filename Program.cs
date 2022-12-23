using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Threading;



namespace Csharplab1
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-QC6OP91\\SQLEXPRESS;Database=Utilities;Integrated Security=true; ");
            await sqlConnection.OpenAsync();
            SqlCommand command = new SqlCommand();

            command.Connection = sqlConnection;
            //command.CommandText = "SELECT Readers.Surname, Readers.Name, Readers.PatronymicName, Readers.Address, Readers.Phone, Readers.DateBirth, Tickets.ID, Books.Author, Books.Name as book, InfoBooks.DateTakeBook, InfoBooks.DateReturnBook, Books.Price  FROM Books INNER JOIN InfoBooks ON Books.ID = InfoBooks.BookID INNER JOIN Tickets ON InfoBooks.TicketID = Tickets.ID INNER JOIN Readers ON Tickets.ReaderID = Readers.ID ORDER BY Readers.Surname, Readers.Name, Readers.PatronymicName";
            command.CommandText = "SELECT Receipts.ID, Consumers.LastName, Consumers.Name, Consumers.MiddleName," +
                                "Addresses.Street, Addresses.House, Addresses.Apartment, Consumers.PersonAccount," +
                                "Services.Service, Receipts.TypeOfPayment, Services.PricePerSquareMeter, Consumers.Square," +
                                "Services.PricePerPerson, Consumers.NumberOfResidents, Receipts.ByDate, Receipts.DateOfPayment," +
                                "Receipts.Amount, Receipts.Benefits, Receipts.Subsidies, Receipts.FinalAmount " +
                                "FROM Receipts INNER JOIN Services ON Receipts.Service = Services.ID " +
                                "INNER JOIN Consumers ON Receipts.Consumer = Consumers.ID " +
                                "INNER JOIN Addresses ON Consumers.Address = Addresses.ID " +
                                "ORDER BY Consumers.LastName, Consumers.Name, Consumers.MiddleName;";

            SqlDataReader dataReader = await command.ExecuteReaderAsync();
            WriteLine("#\tLast Name\tName\tMiddleName\tStreet\tHouse\t" +
                "Apartment\tPerso nAccount\tService\tType Of Payment\tPer Meter\t" +
                "Square\tPer Person\tResidents\tBy Date\tDate Of Payment\t" +
                "Amount\tBenefits\tSubsidies\tFinalAmount\n");

            while (await dataReader.ReadAsync())
            {

                WriteLine($"{dataReader["ID"]}\t{dataReader["LastName"]}\t{dataReader["Name"]}\t" +
                    $"{dataReader["MiddleName"]}\t{dataReader["Street"]}\t{dataReader["House"]}\t{dataReader["Apartment"]}\t" +
                    $"{dataReader["PersonAccount"]}\t{dataReader["Service"]}\t{dataReader["TypeOfPayment"]}\t" +
                    $"{dataReader["PricePerSquareMeter"]}\t{dataReader["Square"]}\t{dataReader["PricePerPerson"]}\t" +
                    $"{dataReader["NumberOfResidents"]}\t{dataReader["ByDate"]}\t{dataReader["DateOfPayment"]}\t" +
                    $"{dataReader["Amount"]}\t{dataReader["Benefits"]}\t{dataReader["Subsidies"]}\t" +
                    $"{dataReader["FinalAmount"]}");
            }
            //await sqlConnection.CloseAsync();
        }
    }
}

