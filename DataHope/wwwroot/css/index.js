//class ChangeColor {
//    //constructor() {
//    //    this.botones = document.getElementsByClassName('boton');
//    //    this.agregarEventos();
//    //}

//    agregarEventos() {
//        this.botones = document.getElementsByClassName('boton');
//        this.botones.forEach((boton) => {
//            boton.addEventListener('click', (event) => {
//                this.cambiarColorBotones('gray');
//                event.target.style.backgroundColor = 'red';
//            });
//        });
//    }

//    cambiarColorBotones(color) {
//        this.botones.forEach((boton) => {
//            boton.style.backgroundColor = color;
//        });
//    }
//}
//let botones;
//function GetButtons(){

//    botones = Array.from(document.getElementsByClassName('boton'));
//}

function ChangeColor() {
    this.botones = Array.from(document.getElementsByClassName('boton'));
    this.botones.forEach((boton) => {
        boton.addEventListener('click', (event) => {
            this.cambiarColorBotones('white');
            boton.style.backgroundColor = 'darkOrange';
        });
    });
}

function cambiarColorBotones(color) {
    this.botones.forEach((boton) => {
        boton.style.backgroundColor = color;
    });
}

//function ChangeColor() {
//    this.botones = document.getElementsByClassName('boton');
//    this.botones.forEach((boton) => {
//        boton.addEventListener('click', (event) => {
//            this.cambiarColorBotones('gray');
//            event.target.style.backgroundColor = 'red';
//        });
//    });
//}

//function cambiarColorBotones(color) {
//    this.botones.forEach((boton) => {
//        boton.style.backgroundColor = color;
//    });
//}

//// Crear una instancia de la clase
//let changeColor = new ChangeColor();
// Exponer una instancia de la clase al objeto window
//window.changeColor = new ChangeColor();



//// Obtén todos los botones con la clase 'miClase'
//let botones = document.querySelectorAll('.boton');

//// Añade un controlador de eventos a cada botón
//botones.forEach((boton) => {
//    boton.addEventListener('click', (event) => {
//        // Cambia el color de todos los botones a gris
//        botones.forEach((boton) => {
//            boton.style.backgroundColor = 'gray';
//        });

//        // Cambia el color del botón clickeado a rojo
//        event.target.style.backgroundColor = 'red';
//    });
//});