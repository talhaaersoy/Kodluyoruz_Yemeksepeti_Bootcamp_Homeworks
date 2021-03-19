import React, { useState } from "react";

const deleted = (func, list, index) => {
  list.splice(index, 1);
  func((list) => [...list]);
};

function TodoList(props) {
  const { setList, todoList } = props;

  return (
    <div className="todoList">
      <ul>
        {todoList.map((list, index) => {
          return (
            <div className="liDiv">
              <li key={index}>
                <p>{list}</p>
                <a
                  href="#"
                  onClick={() => {
                    deleted(setList, todoList, index);
                  }}
                >
                  <i className="far fa-trash-alt text-danger"></i>
                </a>
              </li>
              <hr />
            </div>
          );
        })}
      </ul>
    </div>
  );
}
export default TodoList;
