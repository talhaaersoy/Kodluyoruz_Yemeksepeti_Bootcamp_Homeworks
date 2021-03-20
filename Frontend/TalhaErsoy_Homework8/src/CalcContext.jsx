import React, { useState, createContext } from "react";

export const CalcContext = createContext();

export const CalcProvider = (props) => {
  const [mainText, setMainText] = useState("0");
  const [lastResult, setLastResult] = useState();
  const [currentOperation, setCurrentOperation] = useState();

  const [resetMainTextNextTime, setResetMainTextNextTime] = useState(true);
  const handleKeyClick = (keyLabel, isNumber, operator,tools) => {
    if (isNumber) {
      if (resetMainTextNextTime) {
        setMainText(keyLabel);
        setResetMainTextNextTime(false);
      } else setMainText(mainText + keyLabel);
    } else if (operator) {
      setCurrentOperation(keyLabel);
      setResetMainTextNextTime(true);

      switch (keyLabel) {
        case "+":
          if (lastResult) {
            const result = parseInt(mainText) + lastResult;

            setLastResult(result);
            setMainText(result);
          } else setLastResult(parseInt(mainText));
          break;
        default:
          break;
        case "-":
          if (lastResult) {
            const result = lastResult - parseInt(mainText);
            setLastResult(result);
            setMainText(result);
          } else setLastResult(mainText);
          break;
        case "x":
          if (lastResult) {
            const result = lastResult * parseInt(mainText);
            setLastResult(result);
            setMainText(result);
          } else setLastResult(mainText);
          break;
        case "÷":
          if (lastResult) {
            const result = lastResult / parseInt(mainText);
            setLastResult(result);
            setMainText(result);
          } else setLastResult(mainText);
          break;
          case "=":
            if (lastResult) {
             const result = eval(lastResult + currentOperation + parseInt(mainText)) 
              const resultString = `${lastResult} ${currentOperation} ${mainText}`;
              setLastResult(resultString);
              setMainText(result);
            } else setLastResult(mainText);
            break;
          
      }
    }
    else{
        switch (keyLabel) {
            case "CE":
                setResetMainTextNextTime(true);
                setMainText("0")
            break;
            case "C":
                setResetMainTextNextTime(true);
                setLastResult();
                setCurrentOperation();
                setMainText("0")
            break;
            case "BS":
                const tmp = mainText.split("");
                tmp.splice(tmp.length-1,1);
                tmp.toString();
                setMainText(tmp)
            break;
        
        
        }
    }
  };

  return (
    <CalcContext.Provider
      value={{
        mainText,
        setMainText,
        lastResult,
        setLastResult,
        currentOperation,
        setCurrentOperation,
        handleKeyClick,
      }}
    >
      {props.children}
    </CalcContext.Provider>
  );
};
