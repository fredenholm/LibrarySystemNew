﻿using System;
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
        public static string Aid;
        public static List<AuthorDTO> getAuthorByAid(List<string> Aidlist)
        {
            List<AuthorDTO> dtoAidList = new List<AuthorDTO>();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM AUTHOR WHERE aid = " + Aid, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    AuthorDTO dto = new AuthorDTO();
                    dto.aId = (int)dar["Aid"];
                    dto.firstName = dar["FirstName"] as string;
                    dto.lastName = dar["LastName"] as string;
                    dto.birthYear = (dar["BirthYear"] == DBNull.Value) ? 0 : Convert.ToInt32(dar["BirthYear"].ToString());
                    dtoAidList.Add(dto);
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
            return dtoAidList;
        }
        public static string title;
        public static List<BookDTO> getBookTitle(List<string> booklist)
        {
            List<BookDTO> dtobooklist = new List<BookDTO>();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM BOOK WHERE Title LIKE '%" + title + "%'", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    BookDTO dto = new BookDTO();
                    dto.isbnNo = dar["ISBN"] as string;
                    dto.title = dar["Title"] as string;
                    dto.signId = (int)dar["SignId"];
                    dto.publicationYear = dar["PublicationYear"] as string;
                    dto.publisher = dar["Publisher"] as string;
                    dto.libNumber = (int)dar["LibNo"];
                    dtobooklist.Add(dto);
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

            return dtobooklist;
        }
        public static List<BookDTO> getBookByISBN(string ISBN)
        {
            List<BookDTO> dtoISBNList = new List<BookDTO>();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM BOOK WHERE ISBN = " + ISBN, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    BookDTO dto = new BookDTO();
                    dto.isbnNo = dar["ISBN"] as string;
                    dto.title = dar["Title"] as string;
                    dto.signId = (int)dar["SignId"];
                    dto.publicationYear = dar["PublicationYear"] as string;
                    dto.publisher = dar["Publisher"] as string;
                    dto.libNumber = (int)dar["LibNo"];
                    dtoISBNList.Add(dto);
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
            return dtoISBNList;
        }
        public static string name;
        public static List<AuthorDTO> getAuthorName(List<string> authorlist)
        {
            List<AuthorDTO> dtoauthorlist = new List<AuthorDTO>();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM AUTHOR WHERE FirstName LIKE '%" + name + "%' OR LastName LIKE '%" + name + "%'", con);
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
                    dtoauthorlist.Add(dto);
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

            return dtoauthorlist;
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
        public static int getFirstAuthor()
        {
            int FirstId = 0;
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 Aid FROM AUTHOR", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    FirstId = (int)dar["Aid"];
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

            return FirstId;
        }
        public static int getLastAuthor()
        {
            int LastId = 0;
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT Aid FROM(SELECT TOP 1 Aid FROM AUTHOR ORDER BY Aid DESC) SQ ORDER BY Aid ASC", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    LastId = (int)dar["Aid"];
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

            return LastId;
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
                    dto.signId = (int)dar["SignId"];
                    dto.publicationYear = dar["PublicationYear"] as string;
                    dto.publisher = dar["Publisher"] as string;
                    dto.libNumber = (int)dar["LibNo"];
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
        public static string Person;
        public static List<BorrowerDTO> getBorrowerPersonId(List<string> booklist)
        {
            List<BorrowerDTO> dtoborrowerlist = new List<BorrowerDTO>();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM BORROWER WHERE PersonId = '" + Person + "'", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    BorrowerDTO dto = new BorrowerDTO();
                    dto.Categoryid = (int)dar["Categoryid"];
                    dto.firstName = dar["FirstName"] as string;
                    dto.lastName = dar["LastName"] as string;
                    dto.Address = dar["Address"] as string;
                    dto.Telno = dar["TelNo"] as string;
                    dto.PersonId = dar["PersonId"] as string;
                    dtoborrowerlist.Add(dto);
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

            return dtoborrowerlist;
        }
        public static List<BorrowDTO> getBorrowbyPersonId(List<string> personList)
        {
            List<BorrowDTO> dtoborrowerlist = new List<BorrowDTO>();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM BORROW WHERE BORROW.PersonId = '" + personList + "'", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    BorrowDTO dto = new BorrowDTO();
                    dto.BorrowDate = (DateTime)dar["BorrowDate"];
                    dto.ToBeReturnedDate = (DateTime)dar["ToBeReturnedDate"];
                    dto.ReturnDate = (DateTime)dar["ReturnDate"];
                    dto.barcode = dar["barcode"] as string;
                    dto.PersonId = dar["personid"] as string;
                    dtoborrowerlist.Add(dto);
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

            return dtoborrowerlist;
        }
        public static List<BookDTO> getBorrowerBook(string personId)
        {
            List<BookDTO> dtoborrowList = new List<BookDTO>();
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM BOOK WHERE BOOK.ISBN = (SELECT ISBN FROM COPY WHERE COPY.Barcode =(SELECT BARCODE FROM BORROW WHERE BORROW.PersonId='" + personId + "'));", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    BookDTO dto = new BookDTO();
                    dto.isbnNo = dar["ISBN"] as string;
                    dto.title = dar["Title"] as string;
                    dto.signId = (int)dar["SignId"];
                    dto.publicationYear = dar["PublicationYear"] as string;
                    dto.publisher = dar["Publisher"] as string;
                    dto.libNumber = (int)dar["LibNo"];
                    dtoborrowList.Add(dto);

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
            return dtoborrowList;
        }
        public static List<UserDTO> getAllUsersDAL()
        {
            List<UserDTO> userDTOList = new List<UserDTO>();

            //Connect to the database and read all authors
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM USR", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    UserDTO dto = new UserDTO();
                    dto.PersonId = dar["PersonId"] as string;
                    dto.Username = dar["Username"] as string;
                    dto.Password = dar["Password"] as string;
                    dto.email = dar["email"] as string;
                    dto.Isadmin = (int)dar["Isadmin"];
                    dto.loadStatus = LoadStatus.Ghost;  //Since we are not retrieving the isbn-number list
                    userDTOList.Add(dto);
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
            return userDTOList;
        }
        public static string getUserId(string userid)
        {
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT USR.PersonID FROM USR WHERE USR.Username = + '" + userid + "'", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    Person = dar["PersonId"] as string;
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

            return Person;
        }
        public static void createUser(string personId, string username, string password, string email, int isadmin)
        {
            string _connectionString = DataSource.GetConnectionString("library2");  // Make possible to define and use different connectionstrings 
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO [USR]([PersonId],[Username],[Password],[email],[Isadmin])VALUES('" + personId + "','" + username + "',PWDENCRYPT('" + password + "'),'" + email + "','" + isadmin + "');", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
        }
        public static void createBorrower(string personId, string Firstname, string Lastname, string address, string Telno, int categoryId)
        {
            string _connectionString = DataSource.GetConnectionString("library2");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO BORROWER(PersonId,FirstName,LastName,Address,Telno,CategoryId)VALUES('" + personId + "','" + Firstname + "', '" + Lastname + "', '" + address + "', '" + Telno + "', '" + categoryId + "');", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
        }
        public static string PersonIdExists(string PersonId)
        {
            string _connectionString = DataSource.GetConnectionString("library2");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("SELECT PersonId FROM USR WHERE PersonId = + '" + PersonId + "'", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    Person = dar["PersonId"] as string;
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
            return Person;
        }
        public static string Username;
        public static string UserExists(string Username)
        {
            string _connectionstring = DataSource.GetConnectionString("library2");
            SqlConnection con = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand("SELECT Username FROM USR WHERE Username = + '" + Username + "'", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if(dar.Read())
                {
                    Username = dar["Username"] as string;
                }
            }
            catch(Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return Username;
        }
        public static string PasswordMatch(string username, string Password)
        {
            string confirmPassword = null;
            string _connectionstring = DataSource.GetConnectionString("library2");
            SqlConnection con = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand("SELECT Username FROM USR WHERE Username = '" + username + "' AND PWDCOMPARE('" + Password + "',Password) = 1", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if(dar.Read())
                {
                    confirmPassword = dar["Username"] as string;
                    // currently get 0, must get 1 if the plain text PW matches the encrypted PW in the db
                }
            }
            catch(Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return confirmPassword;
        }

        public static void UpdateAuthor(string EFirstname, string ELastName, int EBirthYear, int EAid)
        { 
            string _connectionString = DataSource.GetConnectionString("library2");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE AUTHOR SET FirstName='" + EFirstname + "',LastName='" + ELastName + "',BirthYear='" + EBirthYear + "' WHERE AID='" + EAid + "'", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
        }
        public static void RemoveAuthor(int aid)
        {
            string _connectionString = DataSource.GetConnectionString("library2");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM Author WHERE Aid='" + aid + "'",con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
        }

        public static void createAuthor(string AFN, string ALN, int ABY)
        {
            string _connectionString = DataSource.GetConnectionString("library2");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("INSERT INTO Author(aid,FirstName,LastName,BirthYear)Values('" + (getLastAuthor() + 1) + "','" + AFN + "','" + ALN + "','" + ABY + "')",con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            } 
    
        }

        public static void RenewLoan(string personId)
        { 
            DateTime today = DateTime.Today;
            today.AddDays(30);
            
            string _connectionString = DataSource.GetConnectionString("library2");
            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("UPDATE BORROW SET ToBeReturnedDate='"+today+"' WHERE PersonId='"+personId +"' ",con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            } 
        }

    }
}
