import logo from "./logo.svg";
import "./App.css";
import Title from "./Components/Title";
import Form from "./Components/Form"
import { useState,useEffect} from "react";
import TodoList from "./Components/TodoList";

function App() {
  const [todoList,setList] = useState([]);
   
  useEffect(() => {
    const findLocalStorage = JSON.parse(localStorage.getItem("Data"))
    if(findLocalStorage !== null){
      setList(JSON.parse(localStorage.getItem("Data")));
    }
    else {

    }

  },[]);
  useEffect(() => {
    localStorage.setItem("Data",JSON.stringify(todoList));
  },[todoList])
  
  return (
    <div className="App">
      <div className="container">
        <div className="todos">
          <div className="titleDiv">
            <Title title = "Todos" />
            <Form setList = {setList}/>
            <TodoList 
            setList = {setList}
            todoList = {todoList}/>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
