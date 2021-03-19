import React from 'react'

const addTodo = async (setList) => {
    
    const text = document.querySelector("#input").value;
    if(text !=""){
    await setList(list => [...list,text]);
    document.querySelector("#input").value = "";
}
    
}
const Form = (props) => {
    const {setList} = props;
    return ( 
        <div className = "todoForm" > 
            <input type="text" placeholder = "Add Todo" id ="input"/>
            <button className = "addButton" type = "submit" onClick = {() => {addTodo(setList);}}> Save</button>
        </div>
    )
}

export default Form;