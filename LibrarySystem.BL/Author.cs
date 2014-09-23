﻿using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using LibrarySystem.DTO;
using LibrarySystem.DAL;

namespace LibrarySystem.BL
{   // Requires references to LirarySystem.DTO and LibrarySystem.DAL
    // Requires references to LirarySystem.DTO and LibrarySystem.DAL
    public class Author
    {
        public static int counter;
        private AuthorDTO _authorDTO;

        #region constructors
        //Initialize a new DTO-object for the transferring data about author
        public Author()
        {
            _authorDTO = new AuthorDTO();
        }

        //A constructor which creates a DTO-object with data from an existing DTO-object
        public Author(AuthorDTO _sourceDTO)
        {
            _authorDTO = new AuthorDTO(_sourceDTO);
        }
        #endregion //Constructors

        #region properties
        // All properties reads the DTO-objects there are no instance variables directly in the Author class 
        public AuthorDTO DTO
        {
            get { return _authorDTO; }
            set { _authorDTO = value; }
        }

        public int AId
        {
            get { return _authorDTO.aId; }
            set { _authorDTO.aId = value; }
        }

        public string FirstName
        {
            get
            {
                Load();
                return _authorDTO.firstName;
            }
            set { _authorDTO.firstName = value; }
        }

        public string LastName
        {
            get
            {
                Load();
                return _authorDTO.lastName;
            }
            set { _authorDTO.lastName = value; }
        }

        public int BirthYear
        {
            get
            {
                Load();
                return _authorDTO.birthYear;
            }
            set { _authorDTO.birthYear = value; }
        }

        public List<string> IsbnList
        {
            get
            {
                Load();
                return _authorDTO.isbnList;
            }
            set { _authorDTO.isbnList = value; }

        }
        public List<string> NameList
        {
            get
            {
                Load();
                return _authorDTO.nameList;
            }
            set { _authorDTO.nameList = value; }
        }
        #endregion  //Properties

        #region private methods
        private void Load()
        {
            // Initiates a read from the database of the DTO-object for a specific author, if loadstatus is set to "Ghost"   
            try
            {
                if (_authorDTO.loadStatus == LoadStatus.Ghost)
                {
                    _authorDTO = LibraryDataAccess.loadAuthorDAL(_authorDTO.aId);
                }
            }
            catch (Exception ex)
            {
                //Do some error-log functionality with ex.Data
            }
        }
        #endregion //private methods

        #region public methods
        public static AuthorDTO findAuthorDTO(string aId)
        {
            AuthorDTO dto = new AuthorDTO();
            return dto;
        }
        public static List<Author> getAll()
        {
            // This method retrieves a list of all authors in the library system
            List<AuthorDTO> dtoList = LibraryDataAccess.getAllAuthorsDAL();  //AuthorDTO is the interface common for BL and DAL

            // Convert to Author objects
            List<Author> results = new List<Author>();
            foreach (AuthorDTO dto in dtoList)
            {
                Author item = new Author(dto);
                results.Add(item);
            }
            return results;
        }
        public static List<Author> getAllbyCount(string Direction)
        {
            List<Author> rangeList = new List<Author>();
            List<AuthorDTO> dtoList = LibraryDataAccess.getAllAuthorsDAL();
            List<Author> results = new List<Author>();
            foreach (AuthorDTO dto in dtoList)
            {
                Author item = new Author(dto);
                results.Add(item);
            }
            if (Direction == "previous")
            {
                if (counter != 0)
                {
                    counter -= 20;
                }
            }
            else if (Direction == "next")
            {
                if (counter + 20 != results.Count)
                {
                    counter += 20;
                }
            }
            if (counter > 40)
            {
                rangeList.RemoveRange(1, 20);
            }
            rangeList.AddRange(results.GetRange(counter, counter + 20));
            return rangeList;
        }
        public static List<Author> getAuthorByName(string Name)
        {
            List<AuthorDTO> dtoList = null; ;
            if (string.IsNullOrEmpty(Name))
            {
                dtoList = LibraryDataAccess.getAllAuthorsDAL();
            }
            else
            {
                // This method retrieves a list of all books in the library system
                LibraryDataAccess.name = Name;
                //Fetch the correct AuthorDTO object and connect an Author object for it
                Author AuthorObject = new Author();
                dtoList = LibraryDataAccess.getAuthorName(AuthorObject.NameList);
            }
            List<Author> results = new List<Author>();
            foreach (AuthorDTO dto in dtoList)
            {
                Author item = new Author(dto);
                results.Add(item);
            }
            return results;
        }

        public bool Update()
        {
            bool updateFlag = true;
            try
            {
                if (_authorDTO.loadStatus == LoadStatus.Loaded)
                {
                    //AuthorDAL.UpdateAuthor.UpdateAuthor(_authorDTO);
                    _authorDTO.loadStatus = LoadStatus.Ghost;
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
        #endregion  //Public methods
    }  //End Class Author
}
