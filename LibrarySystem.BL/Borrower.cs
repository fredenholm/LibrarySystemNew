using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using LibrarySystem.DTO;
using LibrarySystem.DAL;

namespace LibrarySystem.BL
{   // Requires references to LirarySystem.DTO and LibrarySystem.DAL
    public class Borrower
    {
        private BorrowerDTO _BorrowerDTO;

        #region constructors
        //Initialize a new DTO-object for the transferring data about author
        public Borrower()
        {
            _BorrowerDTO = new BorrowerDTO();
        }

        //A constructor which creates a DTO-object with data from an existing DTO-object
        public Borrower(BorrowerDTO _sourceDTO)
        {
            _BorrowerDTO = new BorrowerDTO(_sourceDTO);
        }
        #endregion //Constructors

        #region properties
        // All properties reads the DTO-objects there are no instance variables directly in the Author class 
        public BorrowerDTO DTO
        {
            get { return _BorrowerDTO; }
            set { _BorrowerDTO = value; }
        }

        public string PersonId
        {
            get { return _BorrowerDTO.PersonId; }
            set { _BorrowerDTO.PersonId = value; }
        }

        public string firstName
        {
            get
            {
                Load();
                return _BorrowerDTO.firstName;
            }
            set { _BorrowerDTO.firstName = value; }
        }

        public string LastName
        {
            get
            {
                Load();
                return _BorrowerDTO.lastName;
            }
            set { _BorrowerDTO.lastName = value; }
        }

        public string address
        {
            get
            {
                Load();
                return _BorrowerDTO.Address;
            }
            set { _BorrowerDTO.Address = value; }
        }
        public string TelNo
        {
            get 
            {
                Load();
                return _BorrowerDTO.Telno;
            }
            set { _BorrowerDTO.Telno = value; }
        }
        public int CategoryID
        {
            get
            {
                Load();
                return _BorrowerDTO.Categoryid;
            }
            set { _BorrowerDTO.Categoryid = value; }
        }


        //public List<string> IsbnList
        //{
        //    get
        //    {
        //        Load();
        //        return _BorrowerDTO.isbnList;
        //    }
        //    set { _BorrowerDTO.isbnList = value; }

        //}
        #endregion  //Properties

        #region private methods
        private void Load()
        {
            // Initiates a read from the database of the DTO-object for a specific author, if loadstatus is set to "Ghost"   
            try
            {
                if (_BorrowerDTO.loadStatus == LoadStatus.Ghost)
                {
                    _BorrowerDTO = LibraryDataAccess.LoadallBorrower(_BorrowerDTO.PersonId);
                }
            }
            catch (Exception ex)
            {
                //Do some error-log functionality with ex.Data
            }
        }
        #endregion //private methods

        #region public methods
        // TODO få ut en output

        public static List<Borrower> getBorrowerId(string PersonId)
        {
            List<BorrowerDTO> dtoList = null; ;
            // This method retrieves a list of all books in the library system
            if (string.IsNullOrEmpty(PersonId))
            {
                dtoList = LibraryDataAccess.getAllBorrowerDAL();  //BookDTO is the interface common for BL and DAL
            }
            else
            {
                //Fetch the correct AuthorDTO object and connect an Author object for it
                BorrowerDTO dto = LibraryDataAccess.getBorrowerPersonId(PersonId);
                dto.loadStatus = LoadStatus.Ghost; //Force it to load all data
                Borrower BorrowerObject = new Borrower(dto);
                // Use the author objects IsbnList property 
                dtoList = LibraryDataAccess.getAllBorrowerDAL();
            }
            // Convert to Book objects since UI only references BL (not DAL or DTO)
            List<Borrower> results = new List<Borrower>();
            foreach (BorrowerDTO dto in dtoList)
            {
                Borrower item = new Borrower(dto);
                results.Add(item);
            }
            return results;
        }
        public static List<Borrower> getAll()
        {
            // This method retrieves a list of all authors in the library system
            List<BorrowerDTO> dtoList = LibraryDataAccess.getAllBorrowerDAL(); 

            // Convert to Author objects
            List<Borrower> results = new List<Borrower>();
            foreach (BorrowerDTO dto in dtoList)
            {
                Borrower item = new Borrower(dto);
                results.Add(item);
            }
            return results;
        }
       /* public static List<Author> getAuthorByName(string Name)
        {
            List<BorrowerDTO> dtoList = null; ;
            // This method retrieves a list of all books in the library system
            if (string.IsNullOrEmpty(Name))
            {
                dtoList = LibraryDataAccess.getAllAuthorsDAL();  //BookDTO is the interface common for BL and DAL
            }
            else
            {
                //Fetch the correct AuthorDTO object and connect an Author object for it
                BorrowerDTO dto = LibraryDataAccess.getAuthorName(Name);
                dto.loadStatus = LoadStatus.Ghost; //Force it to load all data
                Author AuthorObject = new Author(dto);
                // Use the author objects IsbnList property 
                dtoList = LibraryDataAccess.getAllAuthorsDAL();
            }
            // Convert to Book objects since UI only references BL (not DAL or DTO)
            List<Author> results = new List<Author>();
            foreach (BorrowerDTO dto in dtoList)
            {
                Author item = new Author(dto);
                results.Add(item);
            }
            return results;
        }*/

        //public bool Update()
        //{
        //    bool updateFlag = true;
        //    try
        //    {
        //        if (_BorrowerDTO.loadStatus == LoadStatus.Loaded)
        //        {
        //            //AuthorDAL.UpdateAuthor.UpdateAuthor(_authorDTO);
        //            _BorrowerDTO.loadStatus = LoadStatus.Ghost;
        //        }
        //        else
        //        {
        //            updateFlag = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Do some error-log functionality with ex.Data
        //    }
        //    return updateFlag;
        //}
        #endregion  //Public methods
    }  //End Class
}
