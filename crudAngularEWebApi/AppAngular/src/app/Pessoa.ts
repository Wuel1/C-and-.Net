export class Pessoa{
    UserID: Number
    Name: String
    LastName: String
    Age: Number

    constructor(userId: Number, name: String, LastName: String, age: Number){
        this.UserID = userId
        this.Name = name
        this.LastName = LastName
        this.Age = age
    }
}