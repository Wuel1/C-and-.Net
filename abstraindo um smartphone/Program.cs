using abstraindo_um_smartphone.models;

class Program
{
    public static void Main(string[] args){
        Iphone iphone13 = new Iphone("Iphone", "13","00001", 128, 18);
        Nokia nokia = new Nokia("Nokia","5","50",512,15);

        iphone13.Ligar();
        nokia.Ligar();

        iphone13.ReceberLigação();
        nokia.ReceberLigação();

        iphone13.InstalarAplicativo("Whatsapp");
        nokia.InstalarAplicativo("Facebook");
    }
}