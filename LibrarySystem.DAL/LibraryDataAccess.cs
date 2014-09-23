using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.DTO;
using System.Data.SqlClient;

namespace LibrarySystem.DAL
{
    public static class LibraryDataAccess
    {
        public static AuthorDTO loadAuthorDAL(int aId)
        {
            AuthorDTO dto = new AuthorDTO();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM AUTHOR WHERE aid = " + aId.ToString(), con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    dto.aId = (int)dar["Aid"];
                    dto.firstName = dar["FirstName"] as string;
                    dto.lastName = dar["LastName"] as string;
                    dto.birthYear = (dar["BirthYear"] == DBNull.Value) ? 0 : Convert.ToInt32(dar["BirthYear"].ToString());
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }

            //Collect all isbn numbers from book_author table
            dto = getAuthorIsbnDAL(dto);
            dto.loadStatus = LoadStatus.Loaded;  // All the data has been loaded into the dto-object

            return dto;
        }
        public static BookDTO getBookTitle(string Title)
        {
            BookDTO dto = new BookDTO();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM book WHERE title = " + Title, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    dto.isbnNo = dar["ISBN"] as string;
                    dto.title = dar["Title"] as string;
                    dto.signId = (int)dar["SignId"];
                    dto.publicationYear = dar["PublicationYear"] as string;
                    dto.publisher = dar["Publisher"] as string;
                    dto.libNumber = (int)dar["LibNo"];
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }

            return dto;
        }
        public static AuthorDTO getAuthorName(string Name)
        {
            AuthorDTO dto = new AuthorDTO();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM AUTHOR WHERE FirstName = " + Name, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    dto.aId = (int)dar["Aid"];
                    dto.firstName = dar["FirstName"] as string;
                    dto.lastName = dar["LastName"] as string;
                    dto.birthYear = (int)dar["BirthYear"];
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }

            return dto;
        }


        public static AuthorDTO getAuthorIsbnDAL(AuthorDTO dto)
        {
            //Connect to the database and read all books for given author
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT isbn FROM book_author WHERE aid = " + dto.aId.ToString(), con);
            try
            {
                string isbn;
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    isbn = dar["ISBN"] as string;
                    dto.isbnList.Add(isbn);
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return dto;
        }

        public static List<AuthorDTO> getAllAuthorsDAL()
        {
            List<AuthorDTO> authorDtoList = new List<AuthorDTO>();

            //Connect to the database and read all authors
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM AUTHOR", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    AuthorDTO dto = new AuthorDTO();
                    dto.aId = (int)dar["Aid"];
                    dto.firstName = dar["FirstName"] as string;
                    dto.lastName = dar["LastName"] as string;
                    dto.birthYear = (dar["BirthYear"] == DBNull.Value) ? 0 : Convert.ToInt32(dar["BirthYear"].ToString());
                    dto.loadStatus = LoadStatus.Ghost;  //Since we are not retrieving the isbn-number list
                    authorDtoList.Add(dto);
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return authorDtoList;
        }

        public static BookDTO loadBookDAL(string isbn)
        {
            BookDTO dto = new BookDTO();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM book WHERE isbn = " + isbn, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    dto.title = dar["Title"] as string;
                    /*                  dto.location = dar["Location"] as string;
                                        dto.classificationCode = dar["ClassificationCode"] as string;
                                        dto.publicationInfo = dar["PublicationInfo"] as string;
                                        dto.pages = (dar["Pages"] == DBNull.Value) ? 0 : Convert.ToInt32(dar["Pages"].ToString());  */
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }

            return dto;
        }

        public static List<BookDTO> getAllBooksDAL()
        {
            List<BookDTO> dtoList = new List<BookDTO>();

            //Connect to the database and read all books
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM book", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    BookDTO dto = new BookDTO();
                    dto.isbnNo = dar["ISBN"] as string;
                    dto.title = dar["Title"] as string;
                    /*                    newBook.location = dar["Location"] as string;
                                        newBook.classificationCode = dar["ClassificationCode"] as string;
                                        newBook.publicationInfo = dar["PublicationInfo"] as string;
                                        newBook.pages = (dar["Pages"] == DBNull.Value) ? 0 : Convert.ToInt32(dar["Pages"].ToString()); */
                    dtoList.Add(dto);
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return dtoList;
        }

        public static List<BookDTO> getAllAuthorBookDAL(List<string> isbnList)
        {
            List<BookDTO> dtoList = new List<BookDTO>();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            string isbnListString = "";
            // Concatenate all isbn-numbers, seperated with comma, into one string
            int itemNo = 0;
            foreach (string str in isbnList)
            {
                itemNo++;
                isbnListString += str + (itemNo == isbnList.Count ? "')" : "','");
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM book WHERE isbn IN ('" + isbnListString, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    BookDTO dto = new BookDTO();
                    dto.isbnNo = dar["ISBN"] as string;
                    dto.title = dar["Title"] as string;
                    /*                    newBook.location = dar["Location"] as string;
                                        newBook.classificationCode = dar["ClassificationCode"] as string;
                                        newBook.publicationInfo = dar["PublicationInfo"] as string;
                                        newBook.pages = (dar["Pages"] == DBNull.Value) ? 0 : Convert.ToInt32(dar["Pages"].ToString()); */
                    dtoList.Add(dto);
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }

            return dtoList;
        }

        public static BorrowerDTO LoadallBorrower(string PersonId)
        {

            BorrowerDTO dto = new BorrowerDTO();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Borrower WHERE PersonId = " + PersonId, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    dto.PersonId = dar["PersonId"] as string;
                    dto.firstName = dar["FirstName"] as string;
                    dto.lastName = dar["LastName"] as string;
                    dto.Address = dar["Address"] as string;
                    dto.Telno = dar["TelNo"] as string;
                    dto.Categoryid = (int)dar["Categoryid"];
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return dto;
        }
        public static List<BorrowerDTO> getAllBorrowerDAL()
        {
            List<BorrowerDTO> BorrowerDtoList = new List<BorrowerDTO>();

            //Connect to the database and read all authors
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM BORROWER", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    BorrowerDTO dto = new BorrowerDTO();
                    dto.Categoryid = (int)dar["Categoryid"];
                    dto.firstName = dar["FirstName"] as string;
                    dto.lastName = dar["LastName"] as string;
                    dto.Address = dar["Address"] as string;
                    dto.Telno = dar["TelNo"] as string;
                    dto.PersonId = dar["PersonId"] as string;
                    dto.loadStatus = LoadStatus.Ghost;  //Since we are not retrieving the isbn-number list
                    BorrowerDtoList.Add(dto);
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return BorrowerDtoList;
        }
        public static BorrowDTO LoadBorrowDAL(string PersonId)
        {

            BorrowDTO dto = new BorrowDTO();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Borrow WHERE PersonId = " + PersonId, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    dto.PersonId = dar["PersonId"] as string;
                    dto.barcode = dar["Barcode"] as string;
                    dto.BorrowDate = (DateTime)dar["BorrowDate"];
                    dto.ToBeReturnedDate = (DateTime)dar["ToBeReturnedDate"];
                    dto.ReturnDate = (DateTime)dar["ReturnDate"];
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return dto;
        }
        public static BorrowerDTO getBorrowerPersonId(string PersonId)
        {
            BorrowerDTO dto = new BorrowerDTO();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM BORROWER WHERE PersonId = '19111111-1111'", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    dto.Categoryid = (int)dar["Categoryid"];
                    dto.firstName = dar["FirstName"] as string;
                    dto.lastName = dar["LastName"] as string;
                    dto.Address = dar["Address"] as string;
                    dto.Telno = dar["TelNo"] as string;
                    dto.PersonId = dar["PersonId"] as string;
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }

            return dto;
        }
    }
}
