﻿SELECT BORROWER.PersonId FROM BORROWER
INTERSECT
SELECT Borrow.PersonId FROM BORROW;