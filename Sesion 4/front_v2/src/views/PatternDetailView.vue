<template>
  <div class="pattern-detail">
    <div class="page-header">
      <div class="header-content">
        <button class="back-btn" @click="goBack">
          ← Volver a Pattern Tracking
        </button>
        <h2>Pattern Tracking Pattern</h2>
      </div>
    </div>

    <!-- Tabs de navegación -->
    <div class="tabs-container">
      <div class="tabs">
        <button 
          class="tab-button active"
          @click="activeTab = 'pattern'"
        >
          Pattern {{ patternData.pattern }} {{ patternData.copy }} {{ patternData.index }}
        </button>
        <button 
          class="tab-button"
          @click="activeTab = 'items'"
        >
          Items
        </button>
        <button 
          class="tab-button"
          @click="activeTab = 'related'"
        >
          Related
        </button>
        <button 
          class="tab-button"
          @click="activeTab = 'attachments'"
        >
          Attachments
        </button>
        <button 
          class="tab-button"
          @click="activeTab = 'history'"
        >
          History
        </button>
        <button 
          class="tab-button"
          @click="activeTab = 'requests'"
        >
          Requests
        </button>
      </div>
    </div>

    <!-- Contenido de la pestaña Pattern -->
    <div v-if="activeTab === 'pattern'" class="tab-content">
      <div class="form-container">
        <div class="form-row">
          <div class="form-group">
            <label for="pattern">Pattern:</label>
            <input type="text" id="pattern" v-model="patternData.pattern" readonly>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="description">Description:</label>
            <input type="text" id="description" v-model="patternData.description">
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="notes">Notes:</label>
            <textarea id="notes" v-model="patternData.notes" rows="3"></textarea>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="drawing">Drawing:</label>
            <input type="text" id="drawing" v-model="patternData.drawing">
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="hydraulic-drawing">Hydraulic Drawing:</label>
            <input type="text" id="hydraulic-drawing" v-model="patternData.hydraulicDrawing">
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="condition">Condition:</label>
            <input type="text" id="condition" v-model="patternData.condition">
          </div>
          <div class="form-group">
            <label for="condition-date">Condition Date:</label>
            <input type="text" id="condition-date" v-model="patternData.conditionDate">
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="manufacture">Manufacture:</label>
            <input type="text" id="manufacture" v-model="patternData.manufacture">
          </div>
          <div class="form-group">
            <label for="manufacturing-cost">Manufacturing Cost:</label>
            <div class="input-with-dropdown">
              <input type="text" id="manufacturing-cost" v-model="patternData.manufacturingCost">
              <select v-model="patternData.manufacturingCostCurrency">
                <option value="EUR">Euro (EUR)</option>
                <option value="USD">US Dollar (USD)</option>
                <option value="MXN">Mexican Peso (MXN)</option>
              </select>
            </div>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="manufacture-date">Manufacture Date:</label>
            <input type="text" id="manufacture-date" v-model="patternData.manufactureDate">
          </div>
          <div class="form-group">
            <label for="index">Index:</label>
            <div class="input-with-dropdown">
              <input type="text" id="index" v-model="patternData.index">
              <button class="dropdown-arrow">▼</button>
            </div>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="add-index">Or Add IndexIndex:</label>
            <input type="text" id="add-index" v-model="patternData.addIndex">
          </div>
          <div class="form-group">
            <label for="index-description">Description (for Index):</label>
            <input type="text" id="index-description" v-model="patternData.indexDescription">
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="molding-type">Molding Type:</label>
            <select id="molding-type" v-model="patternData.moldingType">
              <option value="Unknown">Unknown</option>
              <option value="Sand">Sand</option>
              <option value="Investment">Investment</option>
              <option value="Die">Die</option>
            </select>
          </div>
          <div class="form-group">
            <label for="pattern-fitting">Pattern Fitting:</label>
            <select id="pattern-fitting" v-model="patternData.patternFitting">
              <option value="Unknown">Unknown</option>
              <option value="Standard">Standard</option>
              <option value="Custom">Custom</option>
            </select>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="pump-type">Pump Type:</label>
            <select id="pump-type" v-model="patternData.pumpType">
              <option value="Unknown">Unknown</option>
              <option value="Centrifugal">Centrifugal</option>
              <option value="Positive Displacement">Positive Displacement</option>
            </select>
          </div>
          <div class="form-group">
            <label for="pump-size">Pump Size:</label>
            <input type="text" id="pump-size" v-model="patternData.pumpSize">
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="prints">Prints:</label>
            <input type="text" id="prints" v-model="patternData.prints">
          </div>
          <div class="form-group">
            <label for="casting-weight">Casting Weight:</label>
            <div class="input-with-dropdown">
              <input type="text" id="casting-weight" v-model="patternData.castingWeight">
              <select v-model="patternData.castingWeightUnit">
                <option value="Metric">Metric (Meters/Kilograms)</option>
                <option value="Imperial">Imperial (Feet/Pounds)</option>
              </select>
            </div>
          </div>
        </div>

        <div class="form-row">
          <div class="form-group">
            <label for="casting-material">Casting Material:</label>
            <select id="casting-material" v-model="patternData.castingMaterial">
              <option value="Unknown">Unknown</option>
              <option value="Cast Iron">Cast Iron</option>
              <option value="Steel">Steel</option>
              <option value="Bronze">Bronze</option>
              <option value="Aluminum">Aluminum</option>
            </select>
          </div>
        </div>

        <!-- Botones de acción -->
        <div class="action-buttons">
          <button class="btn btn-primary" @click="updatePattern">Update Pattern</button>
          <button class="btn btn-secondary" @click="duplicatePattern">Duplicate Pattern Copy</button>
        </div>
      </div>
    </div>

    <!-- Contenido de otras pestañas -->
    <div v-else class="tab-content">
      <div class="placeholder-content">
        <p>Contenido de la pestaña "{{ activeTab }}" en desarrollo.</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'PatternDetailView',
  data() {
    return {
      activeTab: 'pattern',
      patternData: {
        pattern: '6703067',
        copy: '1',
        index: '00',
        description: '',
        notes: '1 Modell , 1 Kernkasten , 1 Abstreichbrett',
        drawing: '702230082602',
        hydraulicDrawing: '',
        condition: '0',
        conditionDate: '1/1/0001',
        manufacture: '',
        manufacturingCost: '4730.11',
        manufacturingCostCurrency: 'EUR',
        manufactureDate: '6/11/1952',
        addIndex: '',
        indexDescription: '',
        moldingType: 'Unknown',
        patternFitting: 'Unknown',
        pumpType: 'Unknown',
        pumpSize: '',
        prints: '0',
        castingWeight: '0',
        castingWeightUnit: 'Metric',
        castingMaterial: 'Unknown'
      }
    }
  },
  methods: {
    updatePattern() {
      console.log('Actualizando patrón:', this.patternData);
      alert('Patrón actualizado correctamente');
    },
    duplicatePattern() {
      console.log('Duplicando patrón:', this.patternData);
      alert('Patrón duplicado correctamente');
    },
    goBack() {
      this.$router.push('/pattern-tracking');
    },
    loadPatternData(patternId) {
      const patternsData = {
        1: {
          pattern: '00107',
          copy: '1',
          index: '',
          description: 'SAND CAP 10L/M/H',
          notes: '1 Modell , 1 Kernkasten , 1 Abstreichbrett',
          drawing: '702230082602',
          hydraulicDrawing: '',
          condition: '0',
          conditionDate: '1/1/0001',
          manufacture: '',
          manufacturingCost: '4730.11',
          manufacturingCostCurrency: 'EUR',
          manufactureDate: '6/11/1952',
          addIndex: '',
          indexDescription: '',
          moldingType: 'Unknown',
          patternFitting: 'Unknown',
          pumpType: 'Unknown',
          pumpSize: '',
          prints: '0',
          castingWeight: '0',
          castingWeightUnit: 'Metric',
          castingMaterial: 'Unknown'
        },
        2: {
          pattern: '0X20J3B',
          copy: '1',
          index: '00',
          description: 'HEAVY BOLLARD CSB-9',
          notes: 'Heavy duty bollard pattern for industrial use',
          drawing: '702230082603',
          hydraulicDrawing: '',
          condition: '1',
          conditionDate: '1/1/2023',
          manufacture: 'Ruhrpumpen',
          manufacturingCost: '2500.00',
          manufacturingCostCurrency: 'EUR',
          manufactureDate: '3/15/2023',
          addIndex: '',
          indexDescription: '',
          moldingType: 'Sand',
          patternFitting: 'Standard',
          pumpType: 'Centrifugal',
          pumpSize: 'CSB-9',
          prints: '5',
          castingWeight: '150',
          castingWeightUnit: 'Metric',
          castingMaterial: 'Cast Iron'
        },
        3: {
          pattern: '0X20J3C',
          copy: '1',
          index: '',
          description: 'IMP J 14X10X20',
          notes: 'Impeller pattern for J series pump',
          drawing: '702230082604',
          hydraulicDrawing: 'HYD-001',
          condition: '2',
          conditionDate: '6/1/2023',
          manufacture: 'Ruhrpumpen',
          manufacturingCost: '3200.50',
          manufacturingCostCurrency: 'EUR',
          manufactureDate: '5/20/2023',
          addIndex: '',
          indexDescription: '',
          moldingType: 'Investment',
          patternFitting: 'Custom',
          pumpType: 'Centrifugal',
          pumpSize: 'J-14X10X20',
          prints: '3',
          castingWeight: '85',
          castingWeightUnit: 'Metric',
          castingMaterial: 'Steel'
        }
      };

      if (patternsData[patternId]) {
        this.patternData = { ...this.patternData, ...patternsData[patternId] };
      } else {
        this.patternData.pattern = patternId;
      }
    }
  },
  mounted() {
    const patternId = this.$route.params.id;
    if (patternId) {
      this.loadPatternData(patternId);
    }
  }
}
</script>

<style scoped>
.pattern-detail {
  max-width: 1200px;
  margin: 0 auto;
  background: white;
  border-radius: 8px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

.page-header {
  background: white;
  padding: 20px;
  border-bottom: 1px solid #e5e7eb;
}

.header-content {
  display: flex;
  align-items: center;
  gap: 20px;
}

.back-btn {
  background: #f3f4f6;
  border: 1px solid #d1d5db;
  padding: 8px 16px;
  border-radius: 6px;
  cursor: pointer;
  font-size: 14px;
  color: #374151;
  transition: all 0.3s;
  white-space: nowrap;
}

.back-btn:hover {
  background: #e5e7eb;
  border-color: #9ca3af;
}

.page-header h2 {
  color: #1e40af;
  font-size: 24px;
  font-weight: bold;
  margin: 0;
}

.tabs-container {
  background: #f8fafc;
  border-bottom: 1px solid #e5e7eb;
}

.tabs {
  display: flex;
  overflow-x: auto;
}

.tab-button {
  padding: 12px 20px;
  background: transparent;
  border: none;
  border-bottom: 3px solid transparent;
  cursor: pointer;
  font-size: 14px;
  font-weight: 500;
  color: #6b7280;
  white-space: nowrap;
  transition: all 0.3s;
}

.tab-button:hover {
  color: #374151;
  background: #f3f4f6;
}

.tab-button.active {
  color: #1e40af;
  border-bottom-color: #1e40af;
  background: white;
}

.tab-content {
  padding: 30px;
}

.form-container {
  max-width: 800px;
}

.form-row {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 20px;
  margin-bottom: 20px;
}

.form-group {
  display: flex;
  flex-direction: column;
}

.form-group label {
  font-weight: 500;
  color: #374151;
  margin-bottom: 5px;
  font-size: 14px;
}

.form-group input,
.form-group select,
.form-group textarea {
  padding: 8px 12px;
  border: 1px solid #d1d5db;
  border-radius: 4px;
  font-size: 14px;
  background: white;
}

.form-group input:read-only {
  background: #f9fafb;
  color: #6b7280;
}

.form-group textarea {
  resize: vertical;
  min-height: 80px;
}

.input-with-dropdown {
  display: flex;
  align-items: center;
  gap: 5px;
}

.input-with-dropdown input {
  flex: 1;
}

.input-with-dropdown select {
  min-width: 120px;
}

.dropdown-arrow {
  padding: 8px 12px;
  background: #f3f4f6;
  border: 1px solid #d1d5db;
  border-radius: 4px;
  cursor: pointer;
  font-size: 12px;
}

.action-buttons {
  display: flex;
  gap: 15px;
  margin-top: 30px;
  padding-top: 20px;
  border-top: 1px solid #e5e7eb;
}

.btn {
  padding: 10px 20px;
  border: none;
  border-radius: 6px;
  font-weight: 500;
  cursor: pointer;
  transition: background-color 0.3s;
}

.btn-primary {
  background: #2563eb;
  color: white;
}

.btn-primary:hover {
  background: #1d4ed8;
}

.btn-secondary {
  background: #6b7280;
  color: white;
}

.btn-secondary:hover {
  background: #4b5563;
}

.placeholder-content {
  text-align: center;
  padding: 60px 20px;
  color: #6b7280;
}

@media (max-width: 768px) {
  .header-content {
    flex-direction: column;
    align-items: flex-start;
    gap: 10px;
  }
  
  .form-row {
    grid-template-columns: 1fr;
    gap: 15px;
  }
  
  .tabs {
    flex-wrap: wrap;
  }
  
  .tab-button {
    padding: 10px 15px;
    font-size: 13px;
  }
  
  .action-buttons {
    flex-direction: column;
  }
  
  .input-with-dropdown {
    flex-direction: column;
    align-items: stretch;
  }
}
</style> 