import React from "react";
import Button from "./Button";
const styles = {
  container: {
    width: "100%",
    height: "65%",
    display: "flex",
    flexWrap: "wrap",
  },
};
const Keyboard = () => {
  return (
    <div style={styles.container}>
      <Button label="%" tools/>
      <Button label="CE" tools/>
      <Button label="C" tools/>
      <Button label="BS" tools/>

      <Button label="1/X" tools/>
      <Button label="x²" tools/>
      <Button label="²√X" tools/>
      <Button label="÷" operator/>

      <Button label="7" isNumber />
      <Button label="8" isNumber />
      <Button label="9" isNumber />
      <Button label="x" operator/>

      <Button label="4" isNumber />
      <Button label="5" isNumber />
      <Button label="6" isNumber />
      <Button label="-" operator/>

      <Button label="1" isNumber />
      <Button label="2" isNumber />
      <Button label="3" isNumber />
      <Button label="+" operator/>

      <Button label="+/-" operator/>
      <Button label="0" isNumber />
      <Button label="." operator/>
      <Button label="=" isBlue operator/>
    </div>
  );
};

export default Keyboard;
