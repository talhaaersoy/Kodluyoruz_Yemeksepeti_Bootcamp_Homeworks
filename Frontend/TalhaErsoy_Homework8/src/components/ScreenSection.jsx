import React, { useContext } from "react";
import { CalcContext } from "../CalcContext";

const styles = {
  screenSection: {
    height: "30%",
    width: "100%",
    display: "flex",
    flexDirection: "column",
    justifyContent: "flex-end",
    alignItems: "flex-end",
    
  },
  mainText: {
      paddingRight : 10,
      color : "#fff",
      fontSize : 30,
    },
    lastResult : {
        paddingRight :10,
        fontSize : 20,
        color : "#999",
    }
};

const ScreenSection = () => {
  const {mainText,lastResult,currentOperation} = useContext(CalcContext)
  return (
    <div style={styles.screenSection}>
      <span style={styles.lastResult}>{lastResult}{currentOperation}</span>
      <span style={styles.mainText}>{mainText}</span>
    </div>
  );
};

export default ScreenSection;
