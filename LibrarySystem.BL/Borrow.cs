﻿using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using LibrarySystem.DTO;
using LibrarySystem.DAL;

namespace LibrarySystem.BL
{   // Requires references to LirarySystem.DTO and LibrarySystem.DAL
    public class Borrow
    {
        private BorrowDTO _BorrowDTO;

        #region constructors
        //Initialize a new DTO-object for the transferring data about author
        public Borrow()
        {
            _BorrowDTO = new BorrowDTO();
        }

        //A constructor which creates a DTO-object with data from an existing DTO-object
        public Borrow(BorrowDTO _sourceDTO)
        {
            _BorrowDTO = new BorrowDTO(_sourceDTO);
        }
        #endregion //Constructors

        #region properties
        // All properties reads the DTO-objects there are no instance variables directly in the Author class 
        public BorrowDTO DTO
        {
            get { return _BorrowDTO; }
            set { _BorrowDTO = value; }
        }

        public string PersonId
        {
            get { return _BorrowDTO.PersonId; }
            set { _BorrowDTO.PersonId = value; }
        }

        public string barcode
        {
            get
            {
                Load();
                return _BorrowDTO.barcode;
            }
            set { _BorrowDTO.barcode = value; }
        }

        public DateTime ReturnDate
        {
            get
            {
                Load();
                return _BorrowDTO.ReturnDate;
            }
            set { _BorrowDTO.ReturnDate = value; }
        }

        public DateTime ToBeReturnDate
        {
            get
            {
                Load();
                return _BorrowDTO.ToBeReturnedDate;
            }
            set { _BorrowDTO.ToBeReturnedDate = value; }
        }
        public DateTime BorrowDate
        {
            get
            {
                Load();
                return _BorrowDTO.BorrowDate;
            }
            set { _BorrowDTO.BorrowDate = value; }
        }
        
        #endregion  //Properties

        #region private methods
        private void Load()
        {
            // Initiates a read from the database of the DTO-object for a specific author, if loadstatus is set to "Ghost"   
            try
            {
                if (_BorrowDTO.loadStatus == LoadStatus.Ghost)
                {
                    _BorrowDTO = LibraryDataAccess.LoadBorrowDAL(_BorrowDTO.PersonId);
                }
            }
            catch (Exception ex)
            {
                //Do some error-log functionality with ex.Data
            }
        }
        #endregion //private methods

        #region public methods
        
       
        #endregion
        }
}
