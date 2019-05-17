#include <Arduino.h>
class Carro
{
private:
    String licensePlate;
    String Owner;
    int CarID;
    int PlaceID;
    int FloorID;
    bool State;

public:
    void setLicensePlate(String a)
    {
        licensePlate = a;
    }
    void setOwner(String owner)
    {
        Owner = owner;
    }
    

    String GetlisencePlate()
    {
        return (licensePlate);
    }

    void setState(bool state)
    {
        State = state;
    }

    void SetPlaceID(int placeID)
    {
        PlaceID = placeID;
    }

    int getPlaceID()
    {
        return (PlaceID);
    }
    int getCarID(){
        return(CarID);
    }
    String getOwner(){
        return(Owner);
    }
    bool getstate()
    {
        return (State);
    }
    int getFloorID(){
        return(FloorID);
    }
    String getLicensePlate(){
        return(licensePlate);
    }

    Carro(String licensePlate, int placeID, int carID, String owner, int floorID, bool state)
    {
        licensePlate = licensePlate;
        State = state;
        PlaceID = placeID;
        Owner = owner;
        CarID = carID;
        FloorID = floorID;
    }
    Carro(){
        
    }
};