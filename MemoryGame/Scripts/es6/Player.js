'use strict';

class Player {
    constructor(name, points) {
        this.name = name;
        this.points = points;
    }
    sayName() {
        console.log("Hi, I'm ${this.name}");
    }
}       
export default Player;