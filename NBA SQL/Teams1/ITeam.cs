using System.Drawing.Color;
/*
    Team Interface  
    Few Observations:
        A lot of the teams have the same code. So we need to make it generic to fit alot more stuff.
        Interfaces are used to define a contract of of what it means to be a member of the interface.
    @Author Jacob Lewis
*/
interface ITeam
{
    private Color primary;
    private Color secondary; 
}