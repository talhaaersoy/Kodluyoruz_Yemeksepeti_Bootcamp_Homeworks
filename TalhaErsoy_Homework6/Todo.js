const button = document.querySelector("#button-save");
const todoInput = document.querySelector("#text-input");
const todoList = document.querySelector("#ul-list");
let todoText = [];

document.addEventListener("DOMContentLoaded", () => {

    if (localStorage.getItem("data") != null) {
        let localData = localStorage.getItem("data");
        localData = JSON.parse(localData);
        todoText = localData;
        todoText.map(item => {
            new AddElement(item).create();
        });
    }
});
const addToDo = () => {
    new AddElement(todoInput.value).create();
    todoText.push(todoInput.value)
    todoInput.value = "";
    localStorage.setItem("data", JSON.stringify(todoText));
   
} 

class AddElement {
    constructor(text){
        this.text = text;
    }

    create(){
        
        const item = document.createElement("li");
        const p = document.createElement("p");
        const hr = document.createElement("hr");
        p.innerText = this.text;
        
        item.appendChild(p);
        p.appendChild(hr);
        todoList.appendChild(item);
    }
}
