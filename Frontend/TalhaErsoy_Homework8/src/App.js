import logo from "./logo.svg";
import "./App.css";
import TopHeader from "./components/TopHeader"
import ScreenSection from "./components/ScreenSection";
import Keyboard from "./components/Keyboard";

const styles = {
  container: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    backgroundColor: "#e5e5e5",
    width: "100vw",
    height: "100vh",
  },
  CalcContainer : {
    backgroundColor : "#222",
    width : "25vw",
    height : "70vh",
    minWidth :250,
    maxWidth : 500, 
  }

};

function App() {
  return (
    <div style={styles.container}>
      <div style={styles.CalcContainer}>
        <TopHeader name = "Hesap Makinesi"/>
        <ScreenSection />
        <Keyboard />
      </div>
    </div>
  );
}

export default App;
