#include <Arduino.h>
class Carro
{
private:
    String licensePlate;
    String Owner;
    String  CarID;
    String  PlaceID;
    String  FloorID;
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

    void SetPlaceID(String  placeID)
    {
        PlaceID = placeID;
    }

    String  getPlaceID()
    {
        return (PlaceID);
    }
    String  getCarID(){
        return(CarID);
    }
    String getOwner(){
        return(Owner);
    }
    bool getstate()
    {
        return (State);
    }
    String  getFloorID(){
        return(FloorID);
    }
    String getLicensePlate(){
        return(licensePlate);
    }

    Carro(String licensePlate, String placeID, String  carID, String owner, String  floorID, bool state)
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