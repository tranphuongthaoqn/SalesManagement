﻿using Entity.User;
namespace Entity.DelegateEvent
{
    public delegate void SuccessLogIn(object obj = null);
    public delegate void FormOpen(EUser user);
    public delegate void FormClose(object obj = null);
    public delegate void FormRefresh(object obj = null);
}
