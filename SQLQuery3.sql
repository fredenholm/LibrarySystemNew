﻿SELECT USR.Username from USR WHERE USR.Username = 'elvan' AND PWDCOMPARE('11',USR.Password) = 1;