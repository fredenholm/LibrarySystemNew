using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.DAL;
using LibrarySystem.DTO;

namespace LibrarySystem.BL
{
    public class Book
    {
                private BookDTO _bookDTO;

        #region constructors
        //Initialize a new DTO-object for the transferring data about author
        public Book()
        {
            _bookDTO = new BookDTO();
        }
        
        //A constructor which creates a DTO-object with data from an existing DTO-object
        public Book(BookDTO _sourceDTO)
        {
            _bookDTO = new BookDTO(_sourceDTO);
        }
        #endregion  // constructors

        #region properties
        public BookDTO DTO
        {
            get { return _bookDTO; }
            set { _bookDTO = value; }
        }

        public string ISBN
        {
            get { return _bookDTO.isbnNo;}
            set { _bookDTO.isbnNo = value; }
        }

        public string Title
        {
            get
            {
                Load();
                return _bookDTO.title; 
            }
            set { _bookDTO.title = value; }
        }
        public int SignId
        {
            get
            {
                Load();
                return _bookDTO.signId;
            }
            set { _bookDTO.signId = value; }
        }
        public string PublicationYear
        {
            get
            {
                Load();
                return _bookDTO.publicationYear;
            }
            set { _bookDTO.publicationYear = value; }
        }
        public string Publisher
        {
            get
            {
                Load();
                return _bookDTO.publisher;
            }
            set { _bookDTO.publisher = value; }
        }
        public int LibNo
        {
            get
            {
                Load();
                return _bookDTO.libNumber;
            }
            set { _bookDTO.libNumber = value; }
        }
        public string Location
        {
            get {
                Load(); 
                return _bookDTO.location;
            }
            set { _bookDTO.location = value; }
        }

        public string ClassificationCode
        {
            get {
                Load(); 
                return _bookDTO.classificationCode;
            }
            set { _bookDTO.classificationCode = value; }
        }

        public string PublicationInfo
        {
            get
            {
                Load();
                return _bookDTO.publicationInfo;
            }
            set { _bookDTO.publicationInfo = value; }
        }

        public int Pages
        {
            get
            {
                Load();
                return _bookDTO.pages;
            }
            set { _bookDTO.pages = value; }
        }
        #endregion  // Properties

        #region private methods
        //If the load of data to the database is partial (Ghost) do a full load
        private void Load()
        {
            try
            {
                if(_bookDTO.loadStatus == LoadStatus.Ghost)
                {
                    _bookDTO = LibraryDataAccess.getBookTitle(_bookDTO.isbnNo);
                    _bookDTO.loadStatus = LoadStatus.Loaded;
                }
            }
            catch (Exception ex)
            {
                //Do some error-log functionality with ex.Data
            }
        }
        #endregion  //private methods

        #region public methods
        public static List<Book> getAll(string aId)
        {
            List<BookDTO> dtoList = null; ;
            // This method retrieves a list of all books in the library system
            if (string.IsNullOrEmpty(aId))
            {
                dtoList = LibraryDataAccess.getAllBooksDAL();  //BookDTO is the interface common for BL and DAL
            }
            else
            {
                //Fetch the correct AuthorDTO object and connect an Author object for it
                AuthorDTO dto = LibraryDataAccess.loadAuthorDAL(Convert.ToInt32(aId));
                dto.loadStatus = LoadStatus.Ghost; //Force it to load all data
                Author AuthorObject = new Author(dto);
                // Use the author objects IsbnList property 
                dtoList = LibraryDataAccess.getAllAuthorBookDAL(AuthorObject.IsbnList);
            }
            // Convert to Book objects since UI only references BL (not DAL or DTO)
            List<Book> results = new List<Book>();
            foreach (BookDTO dto in dtoList)
            {
                Book item = new Book(dto);
                results.Add(item);
            }
            return results;
        }

        public static List<Book> getBookByTitle(string Title)
        {
            List<BookDTO> dtoList = null; ;
            // This method retrieves a list of all books in the library system
            if (string.IsNullOrEmpty(Title))
            {
                dtoList = LibraryDataAccess.getAllBooksDAL();  //BookDTO is the interface common for BL and DAL
            }
            else
            {
                //Fetch the correct AuthorDTO object and connect an Author object for it
                BookDTO dto = LibraryDataAccess.getBookTitle(Title);
                dto.loadStatus = LoadStatus.Ghost; //Force it to load all data
                Book AuthorObject = new Book(dto);
                // Use the author objects IsbnList property 
                dtoList = LibraryDataAccess.getAllBooksDAL();
            }
            // Convert to Book objects since UI only references BL (not DAL or DTO)
            List<Book> results = new List<Book>();
            foreach (BookDTO dto in dtoList)
            {
                Book item = new Book(dto);
                results.Add(item);
            }
            return results;
        }

        public bool Update()
        {
            bool updateFlag = true;
            try
            {
                if (_bookDTO.loadStatus == LoadStatus.Loaded)
                {
                    //AuthorDAL.UpdateAuthor.UpdateAuthor(_authorDTO);
                    _bookDTO.loadStatus = LoadStatus.Ghost;
                }
                else
                {
                    updateFlag = false;
                }
            }
            catch (Exception ex)
            {
                //Do some error-log functionality with ex.Data
            }
            return updateFlag;
        }
        #endregion //public methods
    }
}
